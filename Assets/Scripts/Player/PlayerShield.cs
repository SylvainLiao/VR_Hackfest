using UnityEngine;
using System.Collections;

public class PlayerShield : IEquipment
{
    public bool IsCoolDown = false;

    public void OnTriggerEnter(Collider other)
    {
        if (IsCoolDown)
            return;

        if (other.tag == Enum_CharacterTag.Player.ToString())
            return;

        EnemyWeapon weapon = other.GetComponent<EnemyWeapon>();
        if (weapon == null)
            return;

        Player player = CharacterData as Player;

        if (!BlockDeter(player))
        {
            return;
        }
        else
        {
            StartCoroutine(BlockCD(player));
        }

        player.Block();
    }

    private bool BlockDeter(Player player)
    {
        RaycastHit hitinfo;
        if (!Physics.SphereCast(player.BodyTransform.position,0.3f, player.transform.forward, out hitinfo, float.MaxValue, 11))
            return false;
        /*
        if (!hitinfo.collider.gameObject.GetComponent<PlayerShield>())
            return false;
            */
        return true;
    }
    private IEnumerator BlockCD(Player player)
    {
        IsCoolDown = true;
        yield return new WaitForSeconds(player.GetPlayerData().BlockCD);
        Debug.Log("Block CD Time" + player.GetPlayerData().BlockCD);
        IsCoolDown = false;
    }
}
