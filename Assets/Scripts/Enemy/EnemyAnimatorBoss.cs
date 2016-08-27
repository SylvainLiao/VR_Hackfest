using UnityEngine;
using System.Collections;

public class EnemyAnimatorBoss : EnemyAnimator
{

	public override void OnEnable ()
	{
		MusicBeatManager.Instance.OnBeatHalfNotify += OnBeatHalfNotify;
	}

	public override void OnDisable ()
	{
		if (MusicBeatManager.Instance != null)
			MusicBeatManager.Instance.OnBeatHalfNotify -= OnBeatHalfNotify;
	}

	void OnBeatHalfNotify ()
	{
		SetStatus (GetIndexStatus ());
		_IsMoveHorizontal = true;
	}
}