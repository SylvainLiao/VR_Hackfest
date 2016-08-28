using UnityEngine;
using System.Collections;

public class Player : ICharacter
{
    public Transform BodyTransform;

    public float m_TempoEffectiveTime;

    private bool IsDead;

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
        if (IsDead)
            return;

        //Debug.Log("Battle: Player Attack!");

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
        if (IsDead)
            return;

        Debug.Log("Battle: " + this.name + " Block!");
        m_SoundPlayer.PlayOneShot(BlockSound);
    }

    public override void Damaged(int atk, bool hitOnTempo)
    {
        if (IsDead)
            return;

        TablePlayerData playerData = m_TableDataBase as TablePlayerData;

        int dmg = atk - playerData.Defence;
        if (dmg <= 0) dmg = 0;
        CurrentHP -= dmg;

        m_SoundPlayer.PlayOneShot(HitSound);

        if (OnHpChange != null)
            OnHpChange(CurrentHP);

        if (CurrentHP <= 0)
        {
            Dead();
        }

        //Debug.Log("Battle: " + this.name + " Damaged! CurrentHP = " + CurrentHP);
    }

    public override void Dead()
    {
        Debug.Log("Battle: " + this.name + " Dead!");

        //TODO : Game Over
        IsDead = true;

        m_SoundPlayer.PlayOneShot(DeadSound);
    }

    //Player On Hit
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == Enum_CharacterTag.Player.ToString())
            return;

        EnemyWeapon weapon = other.GetComponent<EnemyWeapon>();
        //TODO : Filter Weapon or Shield
        if (weapon == null)
            return;

        EnemyAnimator anim = weapon.CharacterData.gameObject.transform.GetComponent<EnemyAnimator>();
        if (anim.m_AnimatorType != EnemyAnimator.AnimatorType.ATK1 &&
            anim.m_AnimatorType != EnemyAnimator.AnimatorType.ATK2 &&
            anim.m_AnimatorType != EnemyAnimator.AnimatorType.ATK3 &&
            anim.m_AnimatorType != EnemyAnimator.AnimatorType.Dash)
            return;

        Enemy targetBattle = weapon.CharacterData as Enemy;
        TableEnemyData data = targetBattle.GetEnemyData();
        Damaged(data.Attack, false);
    }
}
