using UnityEngine;
using System.Collections;

public class Player : ICharacter
{
    public Transform HeadTransform;

    public float m_TempoEffectiveTime;

    // Use this for initialization
    public override void Initailize()
    {
        m_TableDataBase = DataEnter.Instance.GetTable<TablePlayerDataScriptable>().GetData("PlayerData001");
        TablePlayerData playerData = m_TableDataBase as TablePlayerData;
        CurrentHP = playerData.HP;

        m_SoundPlayer = this.GetComponentInChildren<AudioSource>();
    }

    public TablePlayerData GetPlayerData()
    {
        return m_TableDataBase as TablePlayerData;
    }

    public void Attack(GameObject target, bool hitOnTempo)
    {
        Debug.Log("Battle: Player Attack!");


        m_SoundPlayer.PlayOneShot(AttackSound);

        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damaged(GetPlayerData().Attack, hitOnTempo);
            return;
        }

        EnemyShield shield = target.GetComponent<EnemyShield>();
        if (shield != null)
        {
            enemy = shield.CharacterData as Enemy;
            enemy.Block();
        }
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
        CurrentHP -= dmg;

        m_SoundPlayer.PlayOneShot(HitSound);

        if (OnHpChange != null)
            OnHpChange(CurrentHP);

        Debug.Log("Battle: " + this.name + " Damaged! CurrentHP = " + CurrentHP);
    }

    public override void Dead()
    {
        Debug.Log("Battle: " + this.name + " Dead!");

        //TODO : Game Over

        m_SoundPlayer.PlayOneShot(DeadSound);
    }

    //Player On Hit
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == Enum_CharacterTag.Player.ToString())
            return;

        PlayerWeapon weapon = other.GetComponent<PlayerWeapon>();
        //TODO : Filter Weapon or Shield
        if (weapon == null)
            return;

        Enemy targetBattle = weapon.CharacterData as Enemy;
        Damaged(targetBattle.GetEnemyData().Attack, false);
    }
}
