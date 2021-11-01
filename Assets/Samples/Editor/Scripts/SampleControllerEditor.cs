using System;
using EditorDataStorage.Editor;
using Samples.Scripts;
using UnityEditor;
using UnityEngine;

namespace Samples.Editor.Scripts
{
    [CustomEditor(typeof(SampleController))]
    public class SampleControllerEditor : UnityEditor.Editor
    {
        private Color _someColorEditorField;
        private bool _someBoolEditorField;
        private float _someFloatEditorField;

        private void OnEnable()
        {
            EditorData.GetData(typeof(SampleControllerEditor), ref _someBoolEditorField,
                               nameof(_someBoolEditorField));

            EditorData.GetData(typeof(SampleControllerEditor), ref _someColorEditorField,
                               nameof(_someColorEditorField));

            EditorData.GetData(typeof(SampleControllerEditor), ref _someFloatEditorField,
                               nameof(_someFloatEditorField));
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var bufferBool =
                EditorGUI.Toggle(EditorGUILayout.GetControlRect(), new GUIContent("Some Bool Editor Field"),
                                 _someBoolEditorField);

            if (!_someBoolEditorField.Equals(bufferBool))
            {
                _someBoolEditorField = bufferBool;
                EditorData.SetData(typeof(SampleControllerEditor), nameof(_someBoolEditorField), _someBoolEditorField);
            }
            
            if (!_someBoolEditorField) return;

            var bufferColor = EditorGUI.ColorField(EditorGUILayout.GetControlRect(),
                                                   new GUIContent("Some Color Editor Field"),
                                                   _someColorEditorField);

            if (!_someColorEditorField.Equals(bufferColor))
            {
                _someColorEditorField = bufferColor;

                EditorData.SetData(typeof(SampleControllerEditor), nameof(_someColorEditorField),
                                   _someColorEditorField);
            }

            var bufferFloat = EditorGUI.Slider(EditorGUILayout.GetControlRect(),
                                               new GUIContent("Some Float Editor Field"),
                                               _someFloatEditorField, 0f, 1f);

            if (!_someFloatEditorField.Equals(bufferFloat))
            {
                _someFloatEditorField = bufferFloat;

                EditorData.SetData(typeof(SampleControllerEditor), nameof(_someFloatEditorField),
                                   _someFloatEditorField);
            }
        }
    }
}
