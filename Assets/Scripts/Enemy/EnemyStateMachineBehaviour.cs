﻿using UnityEngine;
using System.Collections;

public class EnemyStateMachineBehaviour : StateMachineBehaviour
{

	public GameObject particle;
	public float radius;
	public float power;

	protected GameObject clone;

	override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	}

	override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	}

	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	}

	override public void OnStateMove (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	}

	override public void OnStateIK (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	}
}
