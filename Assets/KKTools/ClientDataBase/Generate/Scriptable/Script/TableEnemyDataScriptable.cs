using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif

[Serializable]
public class DictionaryTableEnemyData : SerializableDictionary<string, TableEnemyData> { }


public class TableEnemyDataScriptable : ScriptableObjectBase
{
    public static string GameTableName = "EnemyData";
	public List<TableEnemyData> m_TableList = new List<TableEnemyData>();
	public DictionaryTableEnemyData m_TableDict = new DictionaryTableEnemyData();

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

				TableEnemyData table = new TableEnemyData();
				table.id = (string)Convert.ChangeType(splitStr[0], typeof(string));
				table.Attack = (int)Convert.ChangeType(splitStr[1], typeof(int));
				table.Defence = (int)Convert.ChangeType(splitStr[2], typeof(int));
				table.HP = (int)Convert.ChangeType(splitStr[3], typeof(int));

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
        foreach (TableEnemyData item in m_TableList)
            m_TableDict.Add(item.id, item);

		Debug.Log(string.Format("[{0}] GameTable Asset Dictionary is Update. Source:[{1}]", this.name, path));
    }
#else
    public override bool LoadGameTable() { return false; }
#endif

    public TableEnemyData GetData(string id)
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