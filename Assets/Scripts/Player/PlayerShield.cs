using UnityEngine;
using System.Collections;

public class PlayerShield : IEquipment
{
    public bool IsCoolDown = false;

    private Renderer m_Render;

    private float m_BeatCount = 0;

    void Start()
    {
        MusicBeatManager.Instance.OnBeatNotify += ShieldTweenAlpha;

        m_Render = this.GetComponent<Renderer>();
    }

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
           // StartCoroutine(BlockCD(player));
        }

        player.Block();
        ResetTweenAlpha();
    }

    private bool BlockDeter(Player player)
    {
        RaycastHit hitinfo;
        if (!Physics.SphereCast(player.BodyTransform.position,0.5f, player.transform.forward, out hitinfo, float.MaxValue, 11))
            return false;
        /*
        if (!hitinfo.collider.gameObject.GetComponent<PlayerShield>())
            return false;
            */
        return true;
    }

    private void ShieldTweenAlpha()
    {
        m_Render.sharedMaterial.SetFloat("_Rim", m_BeatCount * 0.7f);
        float rim = m_Render.sharedMaterial.GetFloat("_Rim");
        if (rim >= 1.8f)
            m_Render.sharedMaterial.SetFloat("_Rim", 1.8f);
        m_BeatCount++;
        /*
        if (m_BeatCount >= 3)
        {
            m_BeatCount = 0;
            IsCoolDown = true;
        }*/
    }

    private void ResetTweenAlpha()
    {
        this.gameObject.GetComponent<Animator>().Stop();
        m_BeatCount = 0;
        m_Render.sharedMaterial.SetFloat("_Rim",0f);
        IsCoolDown = false;
    }

    /*
    private IEnumerator BlockCD(Player player)
    {
        IsCoolDown = true;
        yield return new WaitForSeconds(MusicBeatManager.Instance.m_BeatTime * 2);
        Debug.Log("Block CD Time" + MusicBeatManager.Instance.m_BeatTime * 2);
        IsCoolDown = false;
    }

    void Update()
    {
        if (IsCoolDown)
        {
            //Shield Color
        }
    }*/
}
