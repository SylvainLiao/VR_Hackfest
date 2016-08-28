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

	public delegate void DeathNofity (int level);

	public event DeathNofity DeathHandle;


	public Player PlayerObject;

	public List<Enemy> EnemyObjectsPool = new List<Enemy> ();

	public GameObject m_GoWave1;
	public GameObject m_GoWave2;
	public GameObject m_GoFight;


	public GameObject[] m_EnemyWave1;
	public GameObject[] m_EnemyWave2;
	public GameObject[] m_EnemyBoss;

	int _DeathCount;

	private void Start ()
	{
		Initailize ();
		_DeathCount = 0;
	}

	public void DeathCountCheck ()
	{
		_DeathCount++;

		if (_DeathCount == m_EnemyWave1.Length) {
			if (DeathHandle != null)
				DeathHandle (1);
		} else if (_DeathCount == m_EnemyWave1.Length + m_EnemyWave2.Length) {
			if (DeathHandle != null)
				DeathHandle (2);
		} else if (_DeathCount == m_EnemyWave1.Length + m_EnemyWave2.Length + m_EnemyBoss.Length) {
			if (DeathHandle != null)
				DeathHandle (3);
		}
	}


	public void Initailize ()
	{
		//PlayerObject.Initailize ();

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
