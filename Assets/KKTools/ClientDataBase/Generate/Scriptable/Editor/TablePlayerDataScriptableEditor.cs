using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TablePlayerDataScriptable))]
public class TablePlayerDataScriptableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TablePlayerDataScriptable script = (TablePlayerDataScriptable)target;

        if (GUILayout.Button("Update"))
			script.LoadGameTable();

        GUILayout.Space(20);

        DrawDefaultInspector();
    }
}