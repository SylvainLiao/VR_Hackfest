using UnityEngine;
using System.Collections;
using SynchronizerData;

public class MyCubeBehaviour : MonoBehaviour {
    private Animator anim;
    BeatObserver beatObserver;
    public BeatValue beatValue = BeatValue.WholeBeat;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        BeatManager bm = Object.FindObjectOfType<BeatManager>();
        //beatObserver = GetComponent<BeatObserver>();
        beatObserver = bm.AddAndRegisterBeatObserver(beatValue, gameObject);
        beatObserver.onBeatMaskChange += OnBeatMaskChange;

    }

    void OnBeatMaskChange(BeatType beatMask)
    {
        Debug.Log(Time.time);
        if ((beatObserver.beatMask & BeatType.DownBeat) == BeatType.DownBeat)
        {
            anim.SetTrigger("DownBeatTrigger");
        }
        if ((beatObserver.beatMask & BeatType.UpBeat) == BeatType.UpBeat)
        {
            transform.Rotate(Vector3.forward, 45f);
        }
    }
    
    /*
    void Update()
    {
        
        if ((beatObserver.beatMask & BeatType.DownBeat) == BeatType.DownBeat)
        {
            Debug.Log(Time.time);
            anim.SetTrigger("DownBeatTrigger");
        }
        if ((beatObserver.beatMask & BeatType.UpBeat) == BeatType.UpBeat)
        {
            transform.Rotate(Vector3.forward, 45f);
        }
    }
    */
    

    void OnDestroy()
    {
        BeatManager bm = Object.FindObjectOfType<BeatManager>();
        bm.RemoveBeatObserver(beatValue, beatObserver);
    }
}
