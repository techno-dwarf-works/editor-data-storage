using System;
using UnityEngine;

namespace Better.EditorStorage.EditorAddons.DataWrappers
{
    [Serializable]
    public class BoundsWrapper : DataWrapper<Bounds>
    {
        public BoundsWrapper(string key, Bounds data) : base(key, data)
        {
        }
    }
}