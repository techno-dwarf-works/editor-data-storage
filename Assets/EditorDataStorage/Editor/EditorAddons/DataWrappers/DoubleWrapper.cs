using System;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class DoubleWrapper : DataWrapper<double>
    {
        public DoubleWrapper(string key, double data) : base(key, data)
        {
        }
    }
}