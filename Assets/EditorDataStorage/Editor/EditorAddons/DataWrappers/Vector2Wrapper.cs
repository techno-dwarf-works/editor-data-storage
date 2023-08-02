using System;
using UnityEngine;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class Vector2Wrapper : DataWrapper<Vector2>
    {
        public Vector2Wrapper(string key, Vector2 data) : base(key, data)
        {
        }
    }
}