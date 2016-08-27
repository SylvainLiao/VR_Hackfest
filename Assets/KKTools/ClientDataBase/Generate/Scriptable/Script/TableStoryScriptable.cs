using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif

[Serializable]
public class DictionaryTableStory : SerializableDictionary<string, TableStory> { }


public class TableStoryScriptable : ScriptableObjectBase
{
    public static string GameTableName = "Story";
	public List<TableStory> m_TableList = new List<TableStory>();
	public DictionaryTableStory m_TableDict = new DictionaryTableStory();

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

				TableStory table = new TableStory();
				table.id = (string)Convert.ChangeType(splitStr[0], typeof(string));
				table.TalkerObjName = (string)Convert.ChangeType(splitStr[1], typeof(string));
				table.FaceObjName = (string)Convert.ChangeType(splitStr[2], typeof(string));
				table.Talk = (string)Convert.ChangeType(splitStr[3], typeof(string));
				table.Talker = (string)Convert.ChangeType(splitStr[4], typeof(string));
				table.TalkTime = (float)Convert.ChangeType(splitStr[5], typeof(float));
				table.AnimIndex = (int)Convert.ChangeType(splitStr[6], typeof(int));

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
        foreach (TableStory item in m_TableList)
            m_TableDict.Add(item.id, item);

		Debug.Log(string.Format("[{0}] GameTable Asset Dictionary is Update. Source:[{1}]", this.name, path));
    }
#else
    public override bool LoadGameTable() { return false; }
#endif

    public TableStory GetData(string id)
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