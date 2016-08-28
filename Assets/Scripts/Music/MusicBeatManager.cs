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
	public event OnBeatHandler OnBeatHalfNotify;


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

	void OnBeatHalf ()
	{
		if (OnBeatHalfNotify != null)
			OnBeatHalfNotify ();
	}

	public void OnPlayBattleNormal ()
	{
		StartCoroutine (PlayBattleNormal ());
	}

	public void OnPlayBattleBoss ()
	{
		StartCoroutine (PlayBattleBoss ());
	}

	IEnumerator PlayBattleNormal ()
	{
		CancelInvoke ("PlayOneShotBeat");
		CancelInvoke ("OnBeatHalf");

		m_BeatTime = 1.5f;
		Play (m_AudioClipMain [0], 0.25f);
		yield return new WaitForSeconds (3.075f);
		Play (m_AudioClipMain [1], 0.25f);
		InvokeRepeating ("PlayOneShotBeat", 0, m_BeatTime);
		InvokeRepeating ("OnBeatHalf", 0, m_BeatTime / 2);
	}

	IEnumerator PlayBattleBoss ()
	{
		CancelInvoke ("PlayOneShotBeat");
		CancelInvoke ("OnBeatHalf");

		m_BeatTime = 1;
		Play (m_AudioClipMain [2], 0.25f);
		yield return new WaitForSeconds (3.3f);
		Play (m_AudioClipMain [3], 0.4f);
		InvokeRepeating ("PlayOneShotBeat", 0, m_BeatTime);
		InvokeRepeating ("OnBeatHalf", 0, m_BeatTime / 2);
	}

	public void PlayOneShot (AudioClip clip)
	{
		m_AudioOther.PlayOneShot (clip);
	}
}
