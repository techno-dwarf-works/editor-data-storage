using System;
using System.Collections.Generic;
using Better.EditorStorage.EditorAddons.DataWrappers;
using Better.Tools.Runtime.Settings;
using UnityEngine;

namespace Better.EditorStorage.EditorAddons.Data
{
    [Serializable]
    public class DataContainer : ISerializationCallbackReceiver
    {
        [SerializeReference] private List<IEditorData> editorDatas = new List<IEditorData>();
        private Dictionary<string, IEditorData> _editorDatas = new Dictionary<string, IEditorData>();

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            editorDatas.Clear();

            foreach (var kvp in _editorDatas)
            {
                editorDatas.Add(kvp.Value);
            }
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            _editorDatas = new Dictionary<string, IEditorData>();

            foreach (var editorData in editorDatas)
            {
                _editorDatas.Add(editorData.Key, editorData);
            }
        }

        internal bool TryGetValue(string key, out IEditorData data)
        {
            return _editorDatas.TryGetValue(key, out data);
        }

        internal IEditorData this[string dataKey]
        {
            get => _editorDatas[dataKey];
            set => _editorDatas[dataKey] = value;
        }

        internal bool ContainsKey(string dataKey)
        {
            return _editorDatas.ContainsKey(dataKey);
        }

        internal void Add(string dataKey, IEditorData data)
        {
            _editorDatas.Add(dataKey, data);
        }
    }

    public sealed class EditorData : ProjectSettings
    {
        [SerializeField] DataContainer editorDataContainer;

        internal IEditorData GetData(string key)
        {
            if (editorDataContainer.TryGetValue(key, out var data))
            {
                return data;
            }

            return default;
        }

        internal void AddData(IEditorData data)
        {
            if (editorDataContainer.ContainsKey(data.Key))
            {
                editorDataContainer[data.Key] = data;
            }
            else
            {
                editorDataContainer.Add(data.Key, data);
            }
        }
    }
}