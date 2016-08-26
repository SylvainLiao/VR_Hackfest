using UnityEngine;
using System.Collections;

public class PlayerBattle : IBattleController
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

    public override void Defence(ITableClassBase data)
    {
        TablePlayerData playerData = m_TableDataBase as TablePlayerData;
        TableEnemyData enemyData = data as TableEnemyData;
    }

    protected override void Damaged(int atk)
    {
        TablePlayerData playerData = m_TableDataBase as TablePlayerData;
        CurrentHP -= atk - playerData.Defence;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == Enum_CharacterTag.Player.ToString())
            return;

        //TODO : Filter Weapon or Shield

        EnemyBattle targetBattle = CharacterManager.Instance.GetEnmeyByName(other.name);
        Damaged(targetBattle.GetEnemyData().Attack);

        if (OnHpChange != null)
            OnHpChange(CurrentHP);
    }
}
