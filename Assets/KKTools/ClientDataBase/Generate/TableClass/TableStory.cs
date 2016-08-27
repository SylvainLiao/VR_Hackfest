using UnityEngine;
using System.Collections;
 
[System.Serializable]
public class TableStory : ITableClassBase
{
	/// <summary>
    /// ##id
    /// </summary>
    public string id { get { return _id; } set { _id = value; } }
	[SerializeField] 
	private string _id;

	/// <summary>
    /// 說話者物件名稱
    /// </summary>
    public string TalkerObjName { get { return _TalkerObjName; } set { _TalkerObjName = value; } }
	[SerializeField] 
	private string _TalkerObjName;

	/// <summary>
    /// 面向物件名稱
    /// </summary>
    public string FaceObjName { get { return _FaceObjName; } set { _FaceObjName = value; } }
	[SerializeField] 
	private string _FaceObjName;

	/// <summary>
    /// 說話
    /// </summary>
    public string Talk { get { return _Talk; } set { _Talk = value; } }
	[SerializeField] 
	private string _Talk;

	/// <summary>
    /// 說話
    /// </summary>
    public string Talker { get { return _Talker; } set { _Talker = value; } }
	[SerializeField] 
	private string _Talker;

	/// <summary>
    /// 說話時間
    /// </summary>
    public float TalkTime { get { return _TalkTime; } set { _TalkTime = value; } }
	[SerializeField] 
	private float _TalkTime;

	/// <summary>
    /// 動作Index
    /// </summary>
    public int AnimIndex { get { return _AnimIndex; } set { _AnimIndex = value; } }
	[SerializeField] 
	private int _AnimIndex;
}