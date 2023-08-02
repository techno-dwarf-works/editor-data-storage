using System;
using UnityEngine;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class Vector4Wrapper : DataWrapper<Vector4>
    {
        public Vector4Wrapper(string key, Vector4 data) : base(key, data)
        {
        }
    }
}