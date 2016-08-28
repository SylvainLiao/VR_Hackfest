using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour
{
	private static CharacterManager m_instance;

	public static CharacterManager Instance {
		get {
			return (m_instance == null) ? new CharacterManager () : m_instance;
		}
	}

	public Player PlayerObject;

	public List<Enemy> EnemyObjectsPool = new List<Enemy> ();

	public GameObject m_GoWave1;
	public GameObject m_GoWave2;
	public GameObject m_GoFight;

	private void Start ()
	{
		Initailize ();
		GameStartFight ();
	}

	public void Initailize ()
	{
		PlayerObject.Initailize ();

		foreach (var obj in EnemyObjectsPool) {
			obj.Initailize ();
		}
	}

	public Enemy GetEnmeyByName (string name)
	{
		for (int i = 0, iCount = EnemyObjectsPool.Count; i < iCount; ++i) {
			if (EnemyObjectsPool [i].name == name)
				return EnemyObjectsPool [i];
		}
		Debug.Log ("Cant Find Enemy With " + name);
		return null;
	}

	public Player GetPlayer ()
	{
		return PlayerObject;
	}

	public void GameStartWave1 ()
	{
		m_GoWave1.SetActive (true);
		MusicBeatManager.Instance.OnPlayBattleNormal ();
	}

	public void GameStartWave2 ()
	{
		m_GoWave2.SetActive (true);
	}

	public void GameStartFight ()
	{
		m_GoFight.SetActive (true);
		MusicBeatManager.Instance.OnPlayBattleBoss ();
	}
}
