using UnityEngine;
using System.Collections;

public class PlayerWeapon : IEquipment
{
    public bool IsAttacking = true;

    public float AttackMinDistance;

    private Vector3 m_LastPosition;

    /*
    private void FixedUpdate()
    {
        AttakDetermination();
    }*/

    public void OnTriggerEnter(Collider other)
    {
        if (!IsAttacking)
            return;

        if (other.tag == Enum_CharacterTag.Player.ToString())
            return;

        EnemyWeapon weapon = other.GetComponent<EnemyWeapon>();
        if (weapon != null)
            return;

        Player player = CharacterData as Player;

        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damaged(player.GetPlayerData().Attack);
            return;
        }

        EnemyShield shield = other.GetComponent<EnemyShield>();
        if (shield != null)
        {
            enemy = shield.CharacterData as Enemy;
            enemy.Block();
        }
    }

    /*
    private void AttakDetermination()
    {
        float moveDist = (this.transform.position - m_LastPosition).magnitude;

        IsAttacking = (moveDist > AttackMinDistance);

        m_LastPosition = this.transform.position;
    }*/

}
