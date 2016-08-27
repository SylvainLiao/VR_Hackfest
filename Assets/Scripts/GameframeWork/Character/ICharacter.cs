using UnityEngine;
using System.Collections;

public enum Enum_CharacterTag
{
    Player,
    Enemy
}

public abstract class ICharacter : MonoBehaviour
{
    protected ITableClassBase m_TableDataBase;

    public IEquipment Weapon;
    public IEquipment Shield;

    public AudioClip HitSound;
    public AudioClip BlockSound;
    public AudioClip AttackSound;

    protected int CurrentHP;

    public delegate void OnHpChangeEvent(int currentHP);
    public OnHpChangeEvent OnHpChange;

    // Use this for initialization
    public abstract void Initailize();
 
    public abstract void Damaged(int atk);
    public abstract void Block();
}
