using System;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class FloatWrapper : DataWrapper<float>
    {
        public FloatWrapper(string key, float data) : base(key, data)
        {
        }
    }
}