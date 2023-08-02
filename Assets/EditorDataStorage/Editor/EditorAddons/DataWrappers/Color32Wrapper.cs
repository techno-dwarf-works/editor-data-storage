using System;
using UnityEngine;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class Color32Wrapper : DataWrapper<Color32>
    {
        public Color32Wrapper(string key, Color32 data) : base(key, data)
        {
        }
    }
}