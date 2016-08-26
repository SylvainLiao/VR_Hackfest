using UnityEngine;
using System.Collections;
 
[System.Serializable]
public class TablePlayerData : ITableClassBase
{
	/// <summary>
    /// ##id
    /// </summary>
    public string id { get { return _id; } set { _id = value; } }
	[SerializeField] 
	private string _id;

	/// <summary>
    /// 攻擊
    /// </summary>
    public int Attack { get { return _Attack; } set { _Attack = value; } }
	[SerializeField] 
	private int _Attack;

	/// <summary>
    /// 防禦
    /// </summary>
    public int Defence { get { return _Defence; } set { _Defence = value; } }
	[SerializeField] 
	private int _Defence;

	/// <summary>
    /// 血量
    /// </summary>
    public int HP { get { return _HP; } set { _HP = value; } }
	[SerializeField] 
	private int _HP;
}