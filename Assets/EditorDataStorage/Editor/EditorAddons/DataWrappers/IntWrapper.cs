using System;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class IntWrapper : DataWrapper<int>
    {
        public IntWrapper(string key, int data) : base(key, data)
        {
        }
    }
}