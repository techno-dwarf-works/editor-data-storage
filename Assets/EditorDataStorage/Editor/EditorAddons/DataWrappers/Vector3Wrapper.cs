using System;
using UnityEngine;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class Vector3Wrapper : DataWrapper<Vector3>
    {
        public Vector3Wrapper(string key, Vector3 data) : base(key, data)
        {
        }
    }
}