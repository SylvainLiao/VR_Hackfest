using UnityEngine;
using System.Collections;

public class MusicBeatManager : SingletonObject<MusicBeatManager>
{
	public AudioSource m_AudioMain;
	public AudioSource m_AudioOther;

	public AudioClip[] m_AudioClipMain;
	public AudioClip m_AudioClipRepeat;

	public float m_BeatTime;

	public delegate void OnBeatHandler ();

	public event OnBeatHandler OnBeatNotify;

	void Start ()
	{
		Play (m_AudioClipMain [1]);

		InvokeRepeating ("PlayOneShotBeat", 0, m_BeatTime);
	}

	public void Play (AudioClip clip)
	{
		m_AudioMain.clip = clip;
		m_AudioMain.Play ();
	}

	void PlayOneShotBeat ()
	{
		m_AudioOther.PlayOneShot (m_AudioClipRepeat);

		if (OnBeatNotify != null)
			OnBeatNotify ();
	}

	public void PlayOneShot (AudioClip clip)
	{
		m_AudioOther.PlayOneShot (clip);
	}
}
