using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class HeartTempo : MonoBehaviour
{

	RectTransform m_TransHeart;

	Tweener _Tweener;

	Vector3 _Scale;

	void Start ()
	{
		m_TransHeart = GetComponent<RectTransform> ();
		_Scale = m_TransHeart.localScale;
	}

	void OnEnable ()
	{
		MusicBeatManager.Instance.OnBeatNotify += OnBeatNotify;
	}

	void OnDisable ()
	{
		MusicBeatManager.Instance.OnBeatNotify -= OnBeatNotify;
	}

	void OnBeatNotify ()
	{
		if (_Tweener != null) {
			if (_Tweener.IsPlaying ()) {
				_Tweener.Kill (true);
			}
		}

		m_TransHeart.localScale = _Scale;
		_Tweener = m_TransHeart.DOScale (Vector3.one * 1.35f, 0.1f).OnComplete (OnScaleComplete);
	}

	void OnScaleComplete ()
	{
		_Tweener = m_TransHeart.DOScale (Vector3.one, 0.1f);
	}

}
