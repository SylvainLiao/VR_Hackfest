using UnityEngine;
using System.Collections;

public class Enemy : ICharacter
{
    private EnemyAnimator m_Animation;

    // Use this for initialization
    public override void Initailize()
    {
        m_TableDataBase = DataEnter.Instance.GetTable<TablePlayerDataScriptable>().GetData("PlayerData001");

        m_SoundPlayer = this.GetComponentInChildren<AudioSource>();

        m_Animation = this.GetComponent<EnemyAnimator>();
    }
    public TableEnemyData GetEnemyData()
    {
        return m_TableDataBase as TableEnemyData;

    }

    public override void Block()
    {
        Debug.Log("Battle: " + this.name + " Block!");
        m_SoundPlayer.PlayOneShot(BlockSound);
    }

    public override void Damaged(int atk, bool hitOnTempo)
    {
        TablePlayerData playerData = m_TableDataBase as TablePlayerData;

        int dmg = atk - playerData.Defence;
        CurrentHP -= hitOnTempo ? Mathf.RoundToInt(dmg * 1.5f) : dmg;

        m_SoundPlayer.PlayOneShot(HitSound);

        if (OnHpChange != null)
            OnHpChange(CurrentHP);

        if (CurrentHP <= 0)
        {
            Dead();
        }

        Debug.Log("Battle: " + this.name + " Damaged! CurrentHP = " + CurrentHP);
    }

    public override void Dead()
    {
        Debug.Log("Battle: "+this.name+" Dead!");

        m_Animation.Death();

        m_SoundPlayer.PlayOneShot(DeadSound);
    }
}
