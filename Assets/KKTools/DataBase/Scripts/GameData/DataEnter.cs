/**********************************************************
// Author   : K.(k79k06k02k)
// FileName : DataEnter.cs
**********************************************************/
using System.Collections.Generic;
using UnityEngine;
using System;


public class DataEnter : Singleton<DataEnter>
{
    public DataPlayer DataPlayer { set; get; }
	public DataMusic DataMusic { set; get; }
	public DataEnemy DataEnemy { set; get; }

    public List<DataBase> m_DataList = new List<DataBase>();
	public Dictionary<Type, ScriptableObjectBase> m_TableList = new Dictionary<Type, ScriptableObjectBase>();
	
    public DataEnter()
    {
    	m_TableList.Add(typeof(TablePlayerDataScriptable), LoadTable(TablePlayerDataScriptable.GameTableName));
    
        DataPlayer = new DataPlayer();
		DataMusic = new DataMusic();
		DataEnemy = new DataEnemy();

        m_DataList.Add(DataPlayer);
		m_DataList.Add(DataMusic);
		m_DataList.Add(DataEnemy);
    }

    /// <summary>
    /// 初始化所有資料層參數
    /// </summary>
    public void RefreshGameData()
    {
        for (int i = 0; i < m_DataList.Count; i++)
            m_DataList[i].RefreshGameData();

        Resources.UnloadUnusedAssets();
    }
    
    /// <summary>
    /// 讀取 Scriptable Asset
    /// </summary>
    /// <param name="isRefeashGameData">名稱</param>
    ScriptableObjectBase LoadTable(string fileName)
    {
        return Utility.AssetRelate.ResourcesLoadCheckNull<ScriptableObjectBase>("ClientDataBase/" + ClientDataBaseConfig.GetScriptableAssetName(fileName));
    }

	/// <summary>
    /// 讀取 Scriptable Script
    /// </summary>
    public T GetTable<T>() where T : class
    {
        return m_TableList[typeof(T)] as T;
    }
    
    


 
}
