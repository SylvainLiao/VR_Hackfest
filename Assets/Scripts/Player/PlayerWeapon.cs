using UnityEngine;
using System.Collections;

public class PlayerWeapon : IEquipment
{
    public bool IsAttacking = true;

    public float AttackMinDistance;

    private Vector3 m_LastPosition;

    private bool HitOnTempo = false;

    void Start()
    {
        MusicBeatManager.Instance.OnBeatNotify += StartCoroutineTempo;
    }

    private void FixedUpdate()
    {
        AttakDetermination();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!IsAttacking)
            return;

        if (other.tag != Enum_CharacterTag.Enemy.ToString())
            return;

        EnemyWeapon weapon = other.GetComponent<EnemyWeapon>();
        if (weapon != null)
            return;

        Debug.Log(string.Format("other.name:{0}，HitOnTempo:{1}", other.name, HitOnTempo));
        Player player = CharacterData as Player;
        player.Attack(other.gameObject, HitOnTempo);
        HitOnTempo = false;
    }

    private void StartCoroutineTempo()
    {
        StopCoroutine("TempoDetermination");
        StartCoroutine("TempoDetermination");
    }

    private IEnumerator TempoDetermination()
    {
        HitOnTempo = true;
        yield return new WaitForSeconds(0.3f);
        HitOnTempo = false;
    }

    private void AttakDetermination()
    {
        float moveDist = (this.transform.position - m_LastPosition).magnitude;

        //Debug.Log("Swipe Distance = "+ moveDist);

        IsAttacking = (moveDist > AttackMinDistance);

        m_LastPosition = this.transform.position;
    }

}
