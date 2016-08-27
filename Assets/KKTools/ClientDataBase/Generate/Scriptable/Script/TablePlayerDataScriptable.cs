using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif

[Serializable]
public class DictionaryTablePlayerData : SerializableDictionary<string, TablePlayerData> { }


public class TablePlayerDataScriptable : ScriptableObjectBase
{
    public static string GameTableName = "PlayerData";
	public List<TablePlayerData> m_TableList = new List<TablePlayerData>();
	public DictionaryTablePlayerData m_TableDict = new DictionaryTablePlayerData();

#if UNITY_EDITOR
	string path;

	public override bool LoadGameTable()
    {        
		m_TableList.Clear();
		m_TableDict.Clear();

        path = ClientDataBaseConfig.GameTablePath + GameTableName + ClientDataBaseConfig.FILE_EXTENSION_TXT;

        TextAsset data = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
        StringReader reader = null;
        int index = 0;
        string strTemp;

        if (data == null)
        {
            Debug.LogError(string.Format("Can't found GameTable txt file in [Path:{0}]", path));
            return false;
        }

        reader = new StringReader(data.text);

        if (reader != null)
        {
            while ((strTemp = reader.ReadLine()) != null)
			{        
				if (index <= 2)
				{
					index++;
					continue;
				}
			        
                string[] splitStr = strTemp.Split("\t"[0]);

				TablePlayerData table = new TablePlayerData();
				table.id = (string)Convert.ChangeType(splitStr[0], typeof(string));
				table.Attack = (int)Convert.ChangeType(splitStr[1], typeof(int));
				table.Defence = (int)Convert.ChangeType(splitStr[2], typeof(int));
				table.HP = (int)Convert.ChangeType(splitStr[3], typeof(int));
				table.BlockCD = (float)Convert.ChangeType(splitStr[4], typeof(float));

                m_TableList.Add(table);

                index++;
            }

            reader.Close();
        }

		MakeUpDictionary();

		EditorUtility.SetDirty(this);
		AssetDatabase.SaveAssets();

        Debug.Log(string.Format("[{0}] GameTable Asset is Update. Source:[{1}]", this.name, path));
		return true;
    }

	void MakeUpDictionary()
    {
        foreach (TablePlayerData item in m_TableList)
            m_TableDict.Add(item.id, item);

		Debug.Log(string.Format("[{0}] GameTable Asset Dictionary is Update. Source:[{1}]", this.name, path));
    }
#else
    public override bool LoadGameTable() { return false; }
#endif

    public TablePlayerData GetData(string id)
    {
        if (m_TableDict.ContainsKey(id))
        {
            return m_TableDict[id];
        }
        else
        {
            Debug.LogWarning(string.Format("[{0}] GameTable Asset Dictionary Can't found key [{1}]", this.name, id));
            return null;
        }
    }
}