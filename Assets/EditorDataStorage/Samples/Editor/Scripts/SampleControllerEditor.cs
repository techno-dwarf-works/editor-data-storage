using System;
using System.Reflection;
using Better.EditorStorage.EditorAddons;
using Samples.Scripts;
using UnityEditor;
using UnityEngine;

namespace Samples.Editor.Scripts
{
    [CustomEditor(typeof(SampleController))]
    public class SampleControllerEditor : UnityEditor.Editor
    {
        private Color _someColorEditorField = EditorDataStorage.GetData<Color>(nameof(_someColorEditorField));
        private bool _someBoolEditorField = EditorDataStorage.GetData<bool>(nameof(_someBoolEditorField));
        private float _someFloatEditorField = EditorDataStorage.GetData<float>(nameof(_someFloatEditorField));

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var bufferBool =
                EditorGUI.Toggle(EditorGUILayout.GetControlRect(), new GUIContent("Some Bool Editor Field"),
                                 _someBoolEditorField);

            if (!_someBoolEditorField.Equals(bufferBool))
            {
                _someBoolEditorField = bufferBool;
                EditorDataStorage.SetData(nameof(_someBoolEditorField), _someBoolEditorField);
            }
            if (!_someBoolEditorField) return;

            var bufferColor = EditorGUI.ColorField(EditorGUILayout.GetControlRect(),
                                                   new GUIContent("Some Color Editor Field"),
                                                   _someColorEditorField);

            if (!_someColorEditorField.Equals(bufferColor))
            {
                _someColorEditorField = bufferColor;
                EditorDataStorage.SetData(nameof(_someColorEditorField), _someColorEditorField);
            }

            var bufferFloat = EditorGUI.Slider(EditorGUILayout.GetControlRect(),
                                               new GUIContent("Some Float Editor Field"),
                                               _someFloatEditorField, 0f, 1f);

            if (!_someFloatEditorField.Equals(bufferFloat))
            {
                _someFloatEditorField = bufferFloat;
                EditorDataStorage.SetData(nameof(_someFloatEditorField), _someFloatEditorField);
            }
        }
    }
}
