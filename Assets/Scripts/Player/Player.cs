using UnityEngine;
using System.Collections;

public class Player : ICharacter
{

    // Use this for initialization
    public override void Initailize()
    {
        m_TableDataBase = DataEnter.Instance.GetTable<TablePlayerDataScriptable>().GetData("PlayerData001");
        TablePlayerData playerData = m_TableDataBase as TablePlayerData;
        CurrentHP = playerData.HP;
    }

    public TablePlayerData GetPlayerData()
    {
        return m_TableDataBase as TablePlayerData;
    }

    public override void Block()
    {
        //TODO BlockSound
    }


    public override void Damaged(int atk)
    {
        TablePlayerData playerData = m_TableDataBase as TablePlayerData;
        CurrentHP -= atk - playerData.Defence;

        //TODO OnHitSound

        if (OnHpChange != null)
            OnHpChange(CurrentHP);
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
        Damaged(targetBattle.GetEnemyData().Attack);
    }
}
