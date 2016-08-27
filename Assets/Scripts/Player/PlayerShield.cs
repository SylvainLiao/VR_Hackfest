using UnityEngine;

public class PlayerShield : IEquipment
{
    public bool IsBlocking = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == Enum_CharacterTag.Player.ToString())
            return;

        EnemyWeapon weapon = other.GetComponent<EnemyWeapon>();
        if (weapon == null)
            return;

        Enemy enemy = weapon.CharacterData as Enemy;
        enemy.Block();
    }
}
