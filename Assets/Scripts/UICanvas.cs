using UnityEngine;
using System.Collections;

public class UICanvas : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject FadeInFadeOut;
    public GameObject UIBeat;
    public GameObject Victory;
    public Animator PlayerOnHit;

    public void PlayerOnHitEffect()
    {
        PlayerOnHit.Play("Flicker");
    }
}
