using System;
using UnityEngine;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class RectWrapper : DataWrapper<Rect>
    {
        public RectWrapper(string key, Rect data) : base(key, data)
        {
        }
    }
}