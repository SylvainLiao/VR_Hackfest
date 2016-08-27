using UnityEngine;
using System.Collections;

public class BeatManager2 : MonoBehaviour {
    public delegate void OnBeatCallback(float gameTime);
	public event OnBeatCallback onBeatCallback;

    public AudioSource backgroundAudioSource;
    public AudioSource beatAudioSource;
    public float startDelay;
    public float repeatRate;
	// Use this for initialization
	void Start () {
        double initTime = AudioSettings.dspTime;
        double realStartDelay = initTime + startDelay;
        backgroundAudioSource.PlayScheduled(initTime + startDelay);
        InvokeRepeating("PlayBeatAudio", startDelay, repeatRate);
    }

    private void PlayBeatAudio()
    {
        beatAudioSource.Play();
        if(onBeatCallback != null)
        {
            onBeatCallback(Time.time);
        }
    }

    public void registerOnBeatCallback(OnBeatCallback callback)
    {
        onBeatCallback += callback;
    }

    public void unregisterOnBeatCallback(OnBeatCallback callback)
    {
        onBeatCallback -= callback;
    }
}
