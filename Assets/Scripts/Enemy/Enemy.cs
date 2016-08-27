using UnityEngine;
using System.Collections;

public class Enemy : ICharacter
{
    // Use this for initialization
    public override void Initailize()
    {
        m_TableDataBase = DataEnter.Instance.GetTable<TablePlayerDataScriptable>().GetData("PlayerData001");
    }
    public TableEnemyData GetEnemyData()
    {
        return m_TableDataBase as TableEnemyData;
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
}
