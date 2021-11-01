﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace EditorDataStorage.Editor
{
    /// <summary>
    /// Editor Data storage class
    /// Allows to store data between working sessions and/or populate it for different copies of Inspector
    /// </summary>
    [CreateAssetMenu(fileName = "EditorDataStorage", menuName = "Custom Editor/Editor Data", order = 0)]
    internal sealed class EditorData : ScriptableObject
    {
        [SerializeField] private TopLevelData data;

        private const string Path = "Editor/Resources";

        private static EditorData _instance;

        private static EditorData Instance
        {
            get
            {
                if (_instance != null) return _instance;
                TryGetOrCreateAsset();
                return _instance;
            }
        }

        /// <summary>
        /// Get field data
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <typeparam name="T"></typeparam>
        /// <remarks>To avoid performance issues in Editor, use this in OnEnable method</remarks>
        internal static void GetData<T>(Type key, ref T value, string fieldName)
        {
            if (!Instance.data.TryGetValue(key, out var data)) return;
            if (data.ContainsKey(fieldName)) value = GetTFromString<T>(data[fieldName]);
        }

        private static T GetTFromString<T>(string input)
        {
            return JsonUtility.FromJson<Wrapper<T>>(input).value;
        }

        /// <summary>
        /// Set field data
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <typeparam name="T"></typeparam>
        /// <remarks>To avoid performance issues in Editor, use this only if value has been changed</remarks>
        internal static void SetData<T>(Type key, string fieldName, T fieldValue)
        {
            if (Instance.data.ContainsKey(key))
            {
                var dic = Instance.data[key];

                if (dic.ContainsKey(fieldName))
                {
                    var wrapper = new Wrapper<T> { value = fieldValue };
                    dic[fieldName] = wrapper.ToString();
                }
                else
                {
                    dic.Add<T>(fieldName, fieldValue);
                }
            }
            else
            {
                var wrapper = new Wrapper<T> { value = fieldValue };
                Instance.data.Add(key, new LowLevelData { key = fieldName, value = wrapper.ToString() });
            }
        }

        private static void TryGetOrCreateAsset()
        {
            if (_instance != null) return;
            _instance = Resources.Load<EditorData>(nameof(EditorData));
            EditorApplication.quitting -= OnQuitting;
            EditorApplication.quitting += OnQuitting;
            if (_instance != null) return;
            _instance = CreateInstance<EditorData>();
            var s = System.IO.Path.Combine(Application.dataPath, Path);
            if (!Directory.Exists(s)) Directory.CreateDirectory(s);

            AssetDatabase.CreateAsset(_instance,
                                      System.IO.Path.Combine("Assets", Path, $"{nameof(EditorData)}.asset"));
        }

        private static void OnQuitting()
        {
            Save();
        }

        /// <summary>
        /// Save EditorData on disk
        /// </summary>
        internal static void Save()
        {
            EditorUtility.SetDirty(Instance);
            AssetDatabase.SaveAssets();
        }

        [Serializable]
        internal sealed class MidLevelData
        {
            public string key;
            public List<LowLevelData> values = new List<LowLevelData>();

            public string this[string fieldName]
            {
                get { return values.FirstOrDefault(x => x.key.Equals(fieldName))?.value; }
                set { values[values.FindIndex(x => x.key.Equals(fieldName))].value = value; }
            }

            public void Add<T>(string fieldName, object fieldValue)
            {
                var wrapper = new Wrapper<T> { value = (T)fieldValue };
                values.Add(new LowLevelData { key = fieldName, value = wrapper.ToString() });
            }

            public bool ContainsKey(string fieldName)
            {
                return values.Any(x => x.key.Equals(fieldName));
            }
        }

        internal sealed class Wrapper<T>
        {
            public T value;

            public override string ToString()
            {
                return JsonUtility.ToJson(this, false);
            }
        }

        [Serializable]
        internal sealed class TopLevelData
        {
            public List<MidLevelData> data = new List<MidLevelData>();

            public MidLevelData this[Type key]
            {
                get { return data.FirstOrDefault(x => x.key.Equals(key.Name)); }
                set { data[data.FindIndex(x => x.key.Equals(key.Name))] = value; }
            }

            public void Add(Type key, LowLevelData lowLevelData)
            {
                data.Add(new MidLevelData { key = key.Name, values = new List<LowLevelData> { lowLevelData } });
            }

            public bool ContainsKey(Type key)
            {
                return data.Any(x => x.key.Equals(key.Name));
            }

            public bool TryGetValue(Type key, out MidLevelData o)
            {
                o = this[key];
                return ContainsKey(key);
            }
        }

        [Serializable]
        internal sealed class LowLevelData
        {
            public string key;
            public string value;
        }
    }
}
