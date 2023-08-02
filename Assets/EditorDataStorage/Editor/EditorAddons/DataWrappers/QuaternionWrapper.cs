using System;
using UnityEngine;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class QuaternionWrapper : DataWrapper<Quaternion>
    {
        public QuaternionWrapper(string key, Quaternion data) : base(key, data)
        {
        }
    }
}