/**********************************************************
// Author   : K.(k79k06k02k)
// FileName : ExhibitGameObject.cs
**********************************************************/
using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(ExhibitGameObject))]
public class ExhibitGameObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ExhibitGameObject _Script = (ExhibitGameObject)target;

        _Script.rowCount = EditorGUILayout.IntField("rowCount", _Script.rowCount);
        _Script.dist = EditorGUILayout.FloatField("dist", _Script.dist);
        _Script.isHideBoxCollider = EditorGUILayout.Toggle("is Hide BoxCollider", _Script.isHideBoxCollider);

        GUILayout.Space(10);
        if (GUILayout.Button("Exhibit Game Object"))
        {
            _Script.Exhibit();
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Reset Transform"))
        {
            _Script.ResetTransform();
        }
        GUILayout.Space(20);
    }

}
#endif

public class ExhibitGameObject : MonoBehaviour
{
    public int rowCount = 10;
    public float dist = 4;
    public bool isHideBoxCollider = false;

    int xIndex = 0;
    int zIndex = 0;

    void Init()
    {
        xIndex = 0;
        zIndex = 0;
    }

    public void Exhibit()
    {
        Init();

        Transform child = null;
        Transform modelChild = null;

        Utility.GameObjectRelate.SortHierarchyObjectChildByName(gameObject.transform);

        for (int i = 0; i < gameObject.transform.childCount; ++i)
        {
            child = gameObject.transform.GetChild(i);

            if (child.gameObject.activeSelf == false)
                continue;

            if (zIndex == rowCount)
            {
                xIndex++;
                zIndex = 0;
            }

            child.localPosition = new Vector3(xIndex * dist, 0, zIndex * dist);
            zIndex++;


            for (int j = 0; j < child.childCount; ++j)
            {
                modelChild = child.GetChild(j);
                if (modelChild.name.IndexOf("BoxCollider", 0) >= 0)
                {
                    modelChild.gameObject.SetActive(isHideBoxCollider == false);
                }
            }
        }
    }

    public void ResetTransform()
    {
        Transform child = null;

        for (int i = 0; i < gameObject.transform.childCount; ++i)
        {
            child = gameObject.transform.GetChild(i);

            if (child.gameObject.activeSelf == false)
                continue;

            Utility.TransformRelate.ResetTransform(child);
        }
    }
}



