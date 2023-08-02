using Better.EditorTools.SettingsTools;
using UnityEditor;

namespace Better.EditorStorage.EditorAddons.Data
{
    public class EditorDataTool : ProjectSettingsTools<EditorData>
    {
        public const string SettingMenuItem = nameof(EditorData);
        public const string MenuItemPrefix = ProjectSettingsRegisterer.BetterPrefix + "/" + SettingMenuItem;

        public EditorDataTool() : base(SettingMenuItem, ObjectNames.NicifyVariableName(SettingMenuItem), new string[]
            { ProjectSettingsRegisterer.BetterPrefix, SettingMenuItem, nameof(Editor), ProjectSettingsRegisterer.ResourcesPrefix })
        {
        }
    }
}