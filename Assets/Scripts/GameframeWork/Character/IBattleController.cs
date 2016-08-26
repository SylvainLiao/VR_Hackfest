using UnityEngine;
using System.Collections;

public enum Enum_CharacterTag
{
    Player,
    Enemy
}

public abstract class IBattleController : MonoBehaviour
{
    protected ITableClassBase m_TableDataBase;

    protected int CurrentHP;

    public delegate void OnHpChangeEvent(int currentHP);
    public OnHpChangeEvent OnHpChange;

    public delegate void OnHitEvent(Collider collider);
    public OnHitEvent OnHit;

    // Use this for initialization
    public abstract void Initailize();
    // m_PlayerData= DataEnter.Instance.GetTable<TablePlayerDataScriptable>().GetData("PlayerData001");
    protected abstract void Damaged(int atk);
    public abstract void Defence(ITableClassBase data);
}
