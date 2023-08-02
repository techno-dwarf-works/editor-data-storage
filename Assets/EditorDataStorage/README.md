# Unity Editor Data Storage

## Description

This small plugin will allow you to store data from editor script and populate it between different copies of Inspector
and/or store fields data between working sessions.

## Usage

### Get data

```c#
private void OnEnable()
{
    EditorData.GetData(this, nameof(_someColorEditorField));
}
```

### Set data

```c#
var bufferColor = EditorGUI.ColorField(EditorGUILayout.GetControlRect(), new GUIContent("Some Color Editor Field"), _someColorEditorField);
if (!_someColorEditorField.Equals(bufferColor))
{
    _someColorEditorField = bufferColor;
    EditorData.SetData(this, nameof(_someColorEditorField));
}
```

## Import
Unpack `EditorDataStorage.unitypackage` in Unity Editor.
<br/><br/>OR<br/><br/>
Place `EditorData.cs` in any `Editor` folder.

## Roadmap

Check [Projects] tab for coming features or bug fixes.

[Projects]: https://github.com/uurha/EditorDataStorage/projects/1

## Notes

Do not hesitate to create issues or ask questions.