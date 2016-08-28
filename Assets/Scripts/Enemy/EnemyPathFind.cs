using UnityEngine;
using System.Collections;
using DG.Tweening;

public class EnemyPathFind : MonoBehaviour
{
	public Transform[] m_TransPaths;
	public float m_Speed;

	EnemyAnimator _EnemyAnimator;

	void Start ()
	{
		_EnemyAnimator = GetComponent<EnemyAnimator> ();
		_EnemyAnimator.PathFind ();

		this.transform.DOMove (m_TransPaths [0].position, 3f).SetEase (Ease.Linear).OnComplete (PathFind);
	}

	void PathFind ()
	{
		this.transform.DORotate (Vector3.up * 90, 0.2f);
		this.transform.DOMove (m_TransPaths [1].position, 3f).SetEase (Ease.Linear).OnComplete (PathFind2);
	}

	void PathFind2 ()
	{		
		_EnemyAnimator.PathFindComplete ();
	}

	//	void Update ()
	//	{
	//		if (index >= m_TransPaths.Length) {
	//			_EnemyAnimator.PathFindComplete ();
	//			this.enabled = false;
	//			return;
	//		}
	//
	//		if (Vector3.Distance (this.transform.position, m_TransPaths [index].position) < 1)
	//			index++;
	//		else
	//			this.transform.position = Vector3.Lerp (this.transform.position, m_TransPaths [index].position, Time.deltaTime * m_Speed);
	//	}
}
