/**********************************************************
// Author   : K.(k79k06k02k)
// FileName : CreateConfigAsset.cs
**********************************************************/
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class CreateConfigAsset
{
    public static void CreateConfig()
    {
        if (EditorUtility.DisplayDialog("",
            "Are you sure?",
            "Yes",
            "No"))
        {
            UnityEngine.Object[] obj = Selection.objects;

            for (int i = 0; i < obj.Length; i++)
            {
                if (obj[i] is MonoScript)
                {
                    MonoScript script = (MonoScript)obj[i];
                    Type type = script.GetClass();

                    if (type.BaseType.Name == "ScriptableObject")
                        CreateScriptableObject(type);
                    else
                        Debug.LogError("[" + AssetDatabase.GetAssetPath(obj[i]) + "] Must Extend ScriptableObject!!");
                }
                else
                {
                    Debug.LogError("[" + AssetDatabase.GetAssetPath(obj[i]) + "] is not MonoScript!!");
                }
            }
        }
    }

    static void CreateScriptableObject(Type type)
    {
        UnityEngine.Object _Object = ScriptableObject.CreateInstance(type);

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        string fileName = Path.GetFileName(path);
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
        path = path.Replace(fileName, "");

        AssetDatabase.CreateAsset(_Object, path + fileNameWithoutExtension + "Asset.asset");
        Debug.Log("[" + path + fileNameWithoutExtension + "Asset.asset" + "] is Create!!");
    }
}