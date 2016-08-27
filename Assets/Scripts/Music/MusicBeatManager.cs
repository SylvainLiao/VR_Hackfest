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
		StartCoroutine (PlayMain ());

		//PlayOneShotBeat();
	}

	public void Play (AudioClip clip, float volume = 1)
	{
		m_AudioMain.volume = volume;
		m_AudioMain.clip = clip;
		m_AudioMain.Play ();
	}

	void PlayOneShotBeat ()
	{
		m_AudioOther.PlayOneShot (m_AudioClipRepeat);

		if (OnBeatNotify != null)
			OnBeatNotify ();
	}

	IEnumerator PlayMain ()
	{
		Play (m_AudioClipMain [0], 0.1f);
		yield return new WaitForSeconds (3.075f);
		Play (m_AudioClipMain [1], 0.1f);
		InvokeRepeating ("PlayOneShotBeat", 0, m_BeatTime);
	}

	public void PlayOneShot (AudioClip clip)
	{
		m_AudioOther.PlayOneShot (clip);
	}
}
