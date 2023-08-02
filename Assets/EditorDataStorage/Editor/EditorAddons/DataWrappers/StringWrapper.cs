using System;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class StringWrapper : DataWrapper<string>
    {
        public StringWrapper(string key, string data) : base(key, data)
        {
        }
    }
}