using UnityEngine;
using System.Collections;

public class EnemyBattle : IBattleController
{
    public float AttackRange;

    // Use this for initialization
    public override void Initailize()
    {
        m_TableDataBase = DataEnter.Instance.GetTable<TablePlayerDataScriptable>().GetData("PlayerData001");
    }
    public TableEnemyData GetEnemyData()
    {
        return m_TableDataBase as TableEnemyData;
    }

    public override void Defence(ITableClassBase data)
    {
        TablePlayerData playerData = data as TablePlayerData;
        TableEnemyData enemyData = m_TableDataBase as TableEnemyData;
    }

    protected override void Damaged(int atk)
    {
        TablePlayerData playerData = m_TableDataBase as TablePlayerData;
        CurrentHP -= atk - playerData.Defence;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == Enum_CharacterTag.Enemy.ToString())
            return;

        //TODO : Filter Weapon or Shield
        PlayerBattle targetBattle = CharacterManager.Instance.GetPlayer();
        Damaged(targetBattle.GetPlayerData().Attack);

        if (OnHpChange != null)
            OnHpChange(CurrentHP);
    }
}
