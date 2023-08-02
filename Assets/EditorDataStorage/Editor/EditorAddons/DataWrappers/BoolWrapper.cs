using System;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class BoolWrapper : DataWrapper<bool>
    {
        public BoolWrapper(string key, bool data) : base(key, data)
        {
        }
    }
}