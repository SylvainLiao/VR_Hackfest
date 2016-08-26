using UnityEngine;
using System.Collections;

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

	int hashMove = Animator.StringToHash ("Base Layer.Move");
	int hashMoveL = Animator.StringToHash ("Base Layer.Move_L");
	int hashMoveR = Animator.StringToHash ("Base Layer.Move_R");

	int _count;

	AnimatorType[] m_Index = new AnimatorType[] { 
		AnimatorType.Move,
		AnimatorType.ATK1,
		AnimatorType.Idle,
		AnimatorType.Block
	};

	AnimatorType[] m_IndexArrival = new AnimatorType[] {
		AnimatorType.ATK1,
		AnimatorType.ATK2,
		AnimatorType.ATK3,
		AnimatorType.Move_L,
		AnimatorType.Move_R
	};

	void Start ()
	{
		_RandomTime = m_RandomTime;
		_count = 0;
	}

	void Update ()
	{
		_RandomTime -= Time.deltaTime;

		if (_RandomTime <= 0) {
			SetStatus (GetIndexStatus ());
			//SetStatus ((AnimatorType)Random.Range (0, 14));
			_RandomTime = m_RandomTime;
			_IsMoveHorizontal = true;
			_count++;
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
		AnimatorType type = m_Index [Random.Range (0, m_Index.Length)];

		if (m_AnimatorTypeLast == type)
			return GetIndexStatus ();
		
		return type;
	}

	AnimatorType GetIndexArrivalStatus ()
	{
		AnimatorType type = m_IndexArrival [Random.Range (0, m_IndexArrival.Length)];

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


}
