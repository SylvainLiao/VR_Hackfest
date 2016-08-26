using UnityEngine;
using System.Collections;
using SynchronizerData;

public class MyCubeBehaviour : MonoBehaviour {
    private Animator anim;
    BeatObserver beatObserver;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        BeatManager bm = Object.FindObjectOfType<BeatManager>();
        //beatObserver = GetComponent<BeatObserver>();
        beatObserver = bm.AddAndRegisterBeatObserver(BeatType.DownBeat, gameObject);
        beatObserver.onBeatMaskChange += OnBeatMaskChange;

    }

    void OnBeatMaskChange(BeatType beatMask)
    {
        Debug.Log("change " + beatObserver.beatMask);
        if ((beatObserver.beatMask & BeatType.DownBeat) == BeatType.DownBeat)
        {
            anim.SetTrigger("DownBeatTrigger");
        }
        if ((beatObserver.beatMask & BeatType.UpBeat) == BeatType.UpBeat)
        {
            transform.Rotate(Vector3.forward, 45f);
        }
    }

    void OnDestroy()
    {
        BeatManager bm = Object.FindObjectOfType<BeatManager>();
        bm.RemoveBeatObserver(BeatType.DownBeat, beatObserver);
    }
}
