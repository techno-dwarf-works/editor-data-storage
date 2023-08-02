using System;
using UnityEngine;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public abstract class DataWrapper<T> : IEditorData
    {
        [SerializeField] private string key;
        [SerializeField] private T data;

        public DataWrapper(string key, T data)
        {
            this.key = key;
            this.data = data;
        }

        public string Key => key;

        public T Data => data;
    }
}