using UnityEngine;
using System.Collections;
using System;

public class EnemyAnimator : MonoBehaviour
{
	public enum AnimatorType
	{
		Idle = 1,
		Alert,
		Victory,
		Block,
		Damage,
		Die1,
		Die2,
		Dash,
		Jump,
		Sit,
		ATK1,
		ATK2,
		ATK3,
		Move,
		Move_R,
		Move_L
	}

	public AnimatorType m_AnimatorType;
	public AnimatorType m_AnimatorTypeLast;
	public GameObject m_GoTarget;
	public Animator m_Animator;
	public float m_PlayerDistance;
	public float m_RandomTime;

	private float _RandomTime;

	bool _IsMoveHorizontal = false;
	bool _IsDeath = false;

	int hashMove = Animator.StringToHash ("Base Layer.Move");
	int hashMoveL = Animator.StringToHash ("Base Layer.Move_L");
	int hashMoveR = Animator.StringToHash ("Base Layer.Move_R");


	void Start ()
	{
		_RandomTime = m_RandomTime;
	}

	void Update ()
	{
		if (_IsDeath)
			return;

		_RandomTime -= Time.deltaTime;

		if (_RandomTime <= 0) {
			SetStatus (GetIndexStatus ());
			_RandomTime = m_RandomTime;
			_IsMoveHorizontal = true;
		}

		AnimatorStateInfo stateInfo = m_Animator.GetCurrentAnimatorStateInfo (0);


		if (stateInfo.fullPathHash == hashMove ||
		    stateInfo.fullPathHash == hashMoveL ||
		    stateInfo.fullPathHash == hashMoveR) {

			if (_IsMoveHorizontal) {
				TargetFollow ();
				_IsMoveHorizontal = false;
			}

			Move ();
		}

	}

	AnimatorType GetIndexStatus ()
	{
		AnimatorType type = (UnityEngine.Random.Range (0, 2) == 0) ? AnimatorType.Move : (AnimatorType)Enum.Parse (typeof(AnimatorType), Config.Enemy.m_Index [UnityEngine.Random.Range (0, Config.Enemy.m_Index.Length)]);

		if (m_AnimatorTypeLast == type)
			return GetIndexStatus ();
		
		return type;
	}

	AnimatorType GetIndexArrivalStatus ()
	{
		AnimatorType type = (AnimatorType)Enum.Parse (typeof(AnimatorType), Config.Enemy.m_IndexArrival [UnityEngine.Random.Range (0, Config.Enemy.m_IndexArrival.Length)]);

		if (m_AnimatorTypeLast == type)
			return GetIndexArrivalStatus ();
		
		return type;
	}

	void SetStatus (AnimatorType type)
	{
		//print ("type:" + type);
		m_AnimatorTypeLast = m_AnimatorType;
		m_AnimatorType = type;
		m_Animator.SetInteger ("animation", (int)type);
	}

	public void TargetFollow ()
	{
		if (Vector3.Distance (this.transform.position, m_GoTarget.transform.position) > 3) {
			
		} else {
			SetStatus (GetIndexArrivalStatus ());
		}

	}

	void Move ()
	{
		if (Vector3.Distance (this.transform.position, m_GoTarget.transform.position) > 3) {
			this.transform.LookAt (m_GoTarget.transform);
			this.transform.Translate (Vector3.forward * Time.deltaTime);
		} else {
			this.transform.LookAt (m_GoTarget.transform);

			Vector3 dist = Vector3.zero;
			if (m_AnimatorType == AnimatorType.Move_L)
				dist = Vector3.left;
			else if (m_AnimatorType == AnimatorType.Move_R)
				dist = Vector3.right;

			this.transform.Translate (dist * Time.deltaTime);
		}
	}

	public void Death ()
	{
		_IsDeath = true;
		SetStatus ((UnityEngine.Random.Range (0, 2) == 0) ? AnimatorType.Die1 : AnimatorType.Die2);

		Destroy (this.gameObject, 3);
	}

}
