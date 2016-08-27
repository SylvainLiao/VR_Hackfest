using UnityEngine;
using System.Collections;

public class MyCubeBehaviour2 : MonoBehaviour {
    private Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        BeatManager2 bm = FindObjectOfType<BeatManager2>();
        bm.registerOnBeatCallback(OnBeat);
    }

    private void OnBeat(float gameTime)
    {
        anim.SetTrigger("DownBeatTrigger");
    }
}
