using System.Collections.Generic;
using Better.EditorTools.SettingsTools;
using UnityEditor;

namespace Better.EditorStorage.EditorAddons.Data
{
    internal class EditorDataProvider : ProjectSettingsProvider<EditorData>
    {
        private readonly Editor _editor;

        public EditorDataProvider() : base(ProjectSettingsToolsContainer<EditorDataTool>.Instance, SettingsScope.Project)
        {
            keywords = new HashSet<string>(new[] { "Better", "Editor", "Data", "Storage" });
            _editor = Editor.CreateEditor(_settings);
        }

        [MenuItem(EditorDataTool.MenuItemPrefix + "/" + ProjectSettingsRegisterer.HighlightPrefix, false, 999)]
        private static void Highlight()
        {
            SettingsService.OpenProjectSettings(ProjectSettingsToolsContainer<EditorDataTool>.Instance.ProjectSettingKey);
        }

        protected override void DrawGUI()
        {
            _editor.OnInspectorGUI();
        }
    }
}