using UnityEngine;
using System.Collections;
using SynchronizerData;

/// <summary>
/// see testing example scene in Scenes/BeatSynchronizer/MyTestScene
/// </summary>
class BeatManager : MonoBehaviour
{
    public BeatCounter downBeatCounter;
    public BeatCounter offBeatCounter;
    public BeatCounter upBeatCounter;
    public BeatCounter onBeatCounter;
    public BeatSynchronizer beatSynchronizer;
    void OnStart()
    {

    }

    public BeatObserver AddAndRegisterBeatObserver(BeatType beatType, GameObject go)
    {
        BeatObserver bo = go.GetComponent<BeatObserver>();
        if(bo == null)
        {
            bo = go.AddComponent<BeatObserver>();
        }
        
        switch(beatType)
        {
            case BeatType.DownBeat:
                downBeatCounter.AddBeatObserver(bo);
                break;
            case BeatType.OffBeat:
                offBeatCounter.AddBeatObserver(bo);
                break;
            case BeatType.OnBeat:
                onBeatCounter.AddBeatObserver(bo);
                break;
            case BeatType.UpBeat:
                upBeatCounter.AddBeatObserver(bo);
                break;
            default:
                Destroy(bo);
                return null;
        }
        return bo;
    }

    public void RemoveBeatObserver(BeatType beatType, BeatObserver observer)
    {
        switch (beatType)
        {
            case BeatType.DownBeat:
                downBeatCounter.RemoveBeatObserver(observer);
                break;
            case BeatType.OffBeat:
                offBeatCounter.RemoveBeatObserver(observer);
                break;
            case BeatType.OnBeat:
                onBeatCounter.RemoveBeatObserver(observer);
                break;
            case BeatType.UpBeat:
                upBeatCounter.RemoveBeatObserver(observer);
                break;
        }
        Destroy(observer);
    }

    public void RemoveBeatObserver(BeatType beatType, GameObject go)
    {
        BeatObserver bo = go.GetComponent<BeatObserver>();
        if(bo == null)
        {
            return;
        }
        RemoveBeatObserver(beatType, bo);
    }

    public void SetAudioClip(AudioClip clip, float bpm, float startDelay)
    {
        beatSynchronizer.SetAudioClip(clip, bpm, startDelay);
    }
}

