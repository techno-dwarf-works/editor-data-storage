using System;
using UnityEngine;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class ColorWrapper : DataWrapper<Color>
    {
        public ColorWrapper(string key, Color data) : base(key, data)
        {
        }
    }
}