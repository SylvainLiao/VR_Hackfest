/**********************************************************
// Author   : K.(k79k06k02k)
// FileName : KKToolsManager.cs
**********************************************************/
using UnityEditor;

public class KKToolsManager
{
    //=======================================================================================
    //Finder
    [MenuItem("KKTools/Finder/Finder")]
    static void Finder_GameObjectFinder()
    {
        GameObjectFinder.ShowWindow();
    }


    //=======================================================================================
    //UGUI
    [MenuItem("KKTools/UGUI/UGUI Tool")]
    static void UGUI_UGUITool()
    {
        UGUITool.ShowWindow();
    }

    [MenuItem("KKTools/UGUI/Canvas Groups Activator")]
    static void UGUI_CanvasGroupActivator()
    {
        CanvasGroupActivator.InitWindow();
    }


    //=======================================================================================
    //Create
    [MenuItem("KKTools/Create/Make Project Folders")]
    static void Create_MakeFolders()
    {
        MakeFolders.ShowWindow();
    }
    [MenuItem("KKTools/Create/Screen Shot Taker")]
    static void Create_ScreenShotTaker()
    {
        ScreenshotTaker.ShowWindow();
    }

    [MenuItem("KKTools/Create/Create Config Asset From Selected")]
    static void Create_CreateConfigAsset()
    {
        CreateConfigAsset.CreateConfig();
    }

    //=======================================================================================
    //Prefab
    [MenuItem("KKTools/Prefab/Prefab Tool")]
    static void Prefab_PrefabTool()
    {
        PrefabTool.ShowView();
    }


    //=======================================================================================
    //Window
    [MenuItem("KKTools/Window/Scene Watcher")]
    static void Window_SceneWatcher()
    {
        SceneWatcher.Init();
    }

    [MenuItem("KKTools/Window/Sorting View")]
    static void Window_SortingView()
    {
        SortingLayerView.ShowWindow();
    }


    //=======================================================================================
    //AssetBundle
    [MenuItem("KKTools/AssetBundle/AssetBundle Analyze")]
    static void AssetBundle_Analyze()
    {
        AssetBundleAnalyzer.ShowWindow();
    }

    [MenuItem("KKTools/AssetBundle/AssetBundle Watch")]
    static void AssetBundle_Watch()
    {
        AssetBundleWatch.ShowWindow();
    }

    [MenuItem("KKTools/AssetBundle/AssetBundle Build Sprite To Prefab")]
    static void AssetBundle_BuildSpriteToPrefab()
    {
        AssetBundleBuild.BuildSpriteToPrefab();
    }

    [MenuItem("KKTools/AssetBundle/AssetBundle Build")]
    static void AssetBundle_Build()
    {
        AssetBundleBuild.ShowWindow();
    }

    [MenuItem("KKTools/AssetBundle/AssetBundle Build All Platform")]
    static void AssetBundle_BuildAllPlatform()
    {
        AssetBundleBuild.BuildAllPlatform();
    }

    [MenuItem("KKTools/AssetBundle/AssetBundle Show All Name")]
    static void AssetBundle_ShowAllNames()
    {
        AssetBundleOther.ShowAllAssetBundleNames();
    }
	 

}