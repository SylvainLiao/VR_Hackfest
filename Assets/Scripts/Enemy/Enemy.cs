using UnityEngine;
using System.Collections;

public class Enemy : ICharacter
{
	private EnemyAnimator m_Animation;

	public string EnemyDataIndex;

	// Use this for initialization
	public void Initailize ()
	{
		m_TableDataBase = DataEnter.Instance.GetTable<TableEnemyDataScriptable> ().GetData (EnemyDataIndex);
		TableEnemyData enemyData = m_TableDataBase as TableEnemyData;
		CurrentHP = enemyData.HP;

		m_SoundPlayer = this.GetComponentInChildren<AudioSource> ();

		m_Animation = this.GetComponent<EnemyAnimator> ();
	}

	public TableEnemyData GetEnemyData ()
	{
		return m_TableDataBase as TableEnemyData;

	}

	public override void Block ()
	{
		Debug.Log ("Battle: " + this.name + " Block!");
		m_SoundPlayer.PlayOneShot (BlockSound);
	}

	public override void Damaged (int atk, bool hitOnTempo)
	{
		if (!hitOnTempo)
			return;

		TableEnemyData enemyData = m_TableDataBase as TableEnemyData;

		int dmg = atk - enemyData.Defence;
		//CurrentHP -= hitOnTempo ? Mathf.RoundToInt(dmg * 1.5f) : dmg;
		if (dmg <= 0)
			dmg = 0;

		CurrentHP -= dmg;

		m_SoundPlayer.PlayOneShot (HitSound);

		if (OnHpChange != null)
			OnHpChange (CurrentHP);

		if (CurrentHP <= 0) {
			Dead ();
		}

		GameObject loadGo = Utility.AssetRelate.ResourcesLoadCheckNull<GameObject> ("Prefabs/FX_Hit");
		Utility.GameObjectRelate.InstantiateGameObject (this.gameObject, loadGo);

		Debug.Log ("Battle: " + this.name + " Damaged! CurrentHP = " + CurrentHP);
	}

	public override void Dead ()
	{
		Debug.Log ("Battle: " + this.name + " Dead!");

		m_Animation.Death ();

		m_SoundPlayer.PlayOneShot (DeadSound);

        if (EnemyDataIndex == "King001")
        {
            VRApplication.Instance.Victory();
        }
	}
}
