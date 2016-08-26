using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TableEnemyDataScriptable))]
public class TableEnemyDataScriptableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TableEnemyDataScriptable script = (TableEnemyDataScriptable)target;

        if (GUILayout.Button("Update"))
			script.LoadGameTable();

        GUILayout.Space(20);

        DrawDefaultInspector();
    }
}