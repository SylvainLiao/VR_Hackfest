using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TableStoryScriptable))]
public class TableStoryScriptableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TableStoryScriptable script = (TableStoryScriptable)target;

        if (GUILayout.Button("Update"))
			script.LoadGameTable();

        GUILayout.Space(20);

        DrawDefaultInspector();
    }
}