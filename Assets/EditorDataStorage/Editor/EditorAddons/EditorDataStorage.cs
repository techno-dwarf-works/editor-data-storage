using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Better.EditorStorage.EditorAddons.Data;
using Better.EditorStorage.EditorAddons.DataWrappers;
using Better.EditorTools.SettingsTools;
using Better.Extensions.Runtime;
using UnityEditor;
using UnityEngine;

namespace Better.EditorStorage.EditorAddons
{
    /// <summary>
    /// Editor Data storage class
    /// Allows to store data between working sessions and/or populate it for different copies of Inspector
    /// </summary>
    [InitializeOnLoad]
    public static class EditorDataStorage
    {
        private static readonly Dictionary<Type, Type> Types;
        private static EditorData _editorData;
        
        private static EditorData EditorDataReference
        {
            get
            {
                _editorData ??= ProjectSettingsToolsContainer<EditorDataTool>.Instance.LoadOrCreateScriptableObject();
                return _editorData;
            }
        }
        
        static EditorDataStorage()
        {
            Types = typeof(IEditorData).GetAllInheritedType().Where(x =>
                    x.BaseType != null && x.BaseType.IsGenericType && x.BaseType.GetGenericTypeDefinition() == typeof(DataWrapper<>))
                .ToDictionary(key => key.BaseType.GenericTypeArguments[0], value => value);
        }

        public static T GetData<T>(string key)
        {
            if (!(EditorDataReference.GetData(key) is DataWrapper<T> data))
            {
                return default;
            }

            return data.Data;
        }

        public static void SetData<T>(string key, T data)
        {
            if (Types.TryGetValue(typeof(T), out var wrapperType))
            {
                var wrapper = (DataWrapper<T>)Activator.CreateInstance(wrapperType, new object[] { key, data });
                EditorDataReference.AddData(wrapper);
            }
        }
    }
}