using UnityEngine;
using System.Collections;

public class OpeningAnimationAnimator : MonoBehaviour {
    public Animator m_Animator;
    public void SetAnimation(int animationType)
    {
        m_Animator.SetInteger("animation", animationType);
    }
}
