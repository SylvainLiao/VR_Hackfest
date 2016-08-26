/**********************************************************
// Author   : K.(k79k06k02k)
// FileName : AssetBundleBuild.cs
**********************************************************/
using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBundleBuild : EditorWindow
{
    bool[] isTargetToggle;

    static string[] BUILD_TARGET_NAMES = { "Android", "IOS", "PC" };

    static string[] PIC_EXTENSION = { "png", "jpg" };

    static string folder = "AssetBundles";

    static string folderPrefab = "GameResources/Prefabs/Sprites";
    static string folderSprite = "GameResources/Sprites";
    static string folderSub;

    static int count = 1;
    static int totalCount = 0;


    public static void BuildSpriteToPrefab()
    {
        DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/" + folderSprite);

        count = 1;
        totalCount = 0;

        foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories())
            foreach (string extension in PIC_EXTENSION)
                foreach (FileInfo pngFile in dirInfo.GetFiles("*." + extension, SearchOption.AllDirectories))
                    totalCount++;


        foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories())
        {
            folderSub = dirInfo.Name;

            foreach (string extension in PIC_EXTENSION)
            {
                foreach (FileInfo pngFile in dirInfo.GetFiles("*." + extension, SearchOption.AllDirectories))
                {
                    CreateSpriteToPrefab(pngFile);
                    count++;
                }
            }
        }

        EditorUtility.ClearProgressBar();
    }

    static void CreateSpriteToPrefab(FileInfo filePic)
    {
        UtilityEditor.CreateFolder(folderPrefab + "/" + folderSub);

        string allPath = filePic.FullName;
        string assetPath = allPath.Substring(allPath.IndexOf("Assets"));

        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
        GameObject go = new GameObject(sprite.name);
        go.AddComponent<SpriteRenderer>().sprite = sprite;

        string prefabPath = "Assets/" + folderPrefab + "/" + folderSub + "/" + sprite.name + ".prefab";

        EditorUtility.DisplayProgressBar("Create Prefab", string.Format("({0} / {1})　Path:[{2}]；Name:[{3}]", count, totalCount, folderPrefab + " / " + folderSub, filePic.Name), count / (float)totalCount);


        GameObject prefab = PrefabUtility.CreatePrefab(prefabPath, go);
        if (prefab != null)
            Debug.Log("Create Prefab in [" + folderPrefab + "/" + folderSub + "]； Name [" + sprite.name + ".prefab" + "] Success!!");
        else
            Debug.LogError("Create Prefab in [" + folderPrefab + "/" + folderSub + "]； Name [" + sprite.name + ".prefab" + "] Faild!!");

        GameObject.DestroyImmediate(go);
    }



    //=================================================================================



    public static void ShowWindow()
    {
        EditorWindow script = EditorWindow.GetWindow(typeof(AssetBundleBuild));
        script.position = new Rect(script.position.xMin + 100f, script.position.yMin + 100f, 600, 120);
        script.autoRepaintOnSceneChange = true;
        script.Show();
        script.titleContent = new GUIContent("AB Build");
    }
    public static void BuildAllPlatform()
    {
        if (EditorUtility.DisplayDialog("",
          "Are you sure?",
          "Yes",
          "No"))
        {
            for (int i = 0; i < BUILD_TARGET_NAMES.Length; i++)
            {
                UtilityEditor.CreateFolder(folder + "/" + BUILD_TARGET_NAMES[i]);

                BuildPipeline.BuildAssetBundles(Application.dataPath + "/" + folder + "/" + BUILD_TARGET_NAMES[i], BuildAssetBundleOptions.CollectDependencies, GetTarget(BUILD_TARGET_NAMES[i]));

            }
        }
    }

    private void OnEnable()
    {
        isTargetToggle = new bool[BUILD_TARGET_NAMES.Length];


        switch (EditorUserBuildSettings.activeBuildTarget)
        {
            case BuildTarget.Android:
                isTargetToggle[0] = true;
                break;

            case BuildTarget.iOS:
                isTargetToggle[1] = true;
                break;

            case BuildTarget.StandaloneWindows:
                isTargetToggle[2] = true;
                break;

            default:
                isTargetToggle[2] = true;
                break;
        }
    }


    void OnGUI()
    {
        EditorGUILayout.LabelField("Choose Build Target", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(25.0f);

        for (int i = 0; i < BUILD_TARGET_NAMES.Length; i++)
        {
            CreateToogle(i, BUILD_TARGET_NAMES[i], isTargetToggle[i]);
        }

        EditorGUILayout.EndHorizontal();
        GUILayout.Space(25.0f);


        if (UtilityEditor.GetCommonButton("Create"))
        {
            if (EditorUtility.DisplayDialog("",
           "Are you sure?",
           "Yes",
           "No"))
            {
                for (int i = 0; i < isTargetToggle.Length; i++)
                {
                    if (isTargetToggle[i])
                    {
                        UtilityEditor.CreateFolder(folder + "/" + BUILD_TARGET_NAMES[i]);

                        BuildPipeline.BuildAssetBundles(Application.dataPath + "/" + folder + "/" + BUILD_TARGET_NAMES[i], BuildAssetBundleOptions.CollectDependencies, GetTarget(BUILD_TARGET_NAMES[i]));
                    }
                }

                this.Close();
            }
        }
    }

    void CreateToogle(int index, string name, bool value)
    {
        isTargetToggle[index] = EditorGUILayout.ToggleLeft("  " + name, value);
    }

    static BuildTarget GetTarget(string name)
    {
        switch (name)
        {
            case "Android":
                return BuildTarget.Android;

            case "iOS":
                return BuildTarget.iOS;

            case "PC":
                return BuildTarget.StandaloneWindows;

            default:
                return BuildTarget.StandaloneWindows;
        }

    }
}
