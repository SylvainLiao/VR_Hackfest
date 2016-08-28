using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class OpenAnimation : MonoBehaviour {

    public GameSceneController m_GameSceneController;
    public GameObject ViveCameraPrefab;
    public GameObject BlackFilterAnimatorHolder;
    public GameObject ScreenCanvas;
    public Transform battleTransform;
    public GameObject UICamera;
    public GameObject ViveControllerLeft;
    public GameObject ViveControllerRight;
    public struct OpeningAnimationAction
    {
        public string dialogContent;
        public Text dialogText;
        public OpeningAnimationAnimator animator;
        public int animationIndex;
        public OpeningAnimationAction(string dialogContent, Text dialogText,
            OpeningAnimationAnimator animator, int animationIndex)
        {
            this.dialogContent = dialogContent;
            this.dialogText = dialogText;
            this.animator = animator;
            this.animationIndex = animationIndex;
        }
    }

    public Text SaladinText;
    public Text LueText;
    public Text RenauldText;
    public OpeningAnimationAnimator SaladinAnimator;
    public OpeningAnimationAnimator LueAnimator;
    public OpeningAnimationAnimator RenauldAnimator;
    private List<OpeningAnimationAction> openingAnimationActionList = new List<OpeningAnimationAction>(); 


    private string[] dialogContentArray =
    {
        "你們家雷納不斷掠奪我們的商隊，" + Environment.NewLine + "還俘虜了商人們! 快把他們放了!",
        "欸~ 薩拉丁叫你放了商人們~ " + Environment.NewLine + "咖乖ㄟ~ 不要讓我難做人~",
        "不要勒~",
        "E04....",
        "他不放人",
        "那就別怪我了!!"
    };
    
	// Use this for initialization
	void Start () {
        openingAnimationActionList.Add(
            new OpeningAnimationAction("你們家雷納不斷掠奪我們的商隊，" + Environment.NewLine + "還俘虜了商人們! 快把他們放了!",
                SaladinText, SaladinAnimator, 12));

        openingAnimationActionList.Add(
            new OpeningAnimationAction("欸~ 薩拉丁叫你放了商人們~ " + Environment.NewLine + "咖乖ㄟ~ 不要讓我難做人~",
        LueText, LueAnimator, 1));

        openingAnimationActionList.Add(
    new OpeningAnimationAction("不要勒~",
RenauldText, RenauldAnimator, 1));

        openingAnimationActionList.Add(
new OpeningAnimationAction("E04....",
LueText, LueAnimator, 1));

        openingAnimationActionList.Add(
new OpeningAnimationAction("他不放人",
LueText, LueAnimator, 1));

        openingAnimationActionList.Add(
new OpeningAnimationAction("那就別怪我了!!",
SaladinText, SaladinAnimator, 13));

        openingAnimationActionList.Add(
new OpeningAnimationAction("他們不放人耶! 乎系!",
SaladinText, SaladinAnimator, 13));
        //set idle
        SaladinAnimator.SetAnimation(1);
        LueAnimator.SetAnimation(1);
        RenauldAnimator.SetAnimation(1);


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TestAnimationEvemt(int index)
    {
        if (index == 7)
        //if (index == 0)
        {
            //go to battle
            ScreenCanvas.SetActive(true);
            BlackFilterAnimatorHolder.SetActive(true);
            UICamera.SetActive(true);
            //BlackFilterAnimatorHolder.GetComponent<Animator>().Play("FadeIn", 0);
            Invoke("AfterExecuteFadeIn", 0.5f);
        }
        else
        {
            OpeningAnimationAction oaa = openingAnimationActionList[index];
            oaa.dialogText.text = oaa.dialogContent;
            oaa.animator.SetAnimation(oaa.animationIndex);
        }

    }

    public void AfterExecuteFadeIn()
    {
        ViveCameraPrefab.transform.position = battleTransform.position;
        BlackFilterAnimatorHolder.GetComponent<Animator>().Play("FadeOut", 0);
        Invoke("AfterExecuteFadeOut", 0.5f);
    }

    public void AfterExecuteFadeOut()
    {
        BlackFilterAnimatorHolder.SetActive(false);
        ScreenCanvas.SetActive(true);
        ViveControllerLeft.SetActive(true);
        ViveControllerRight.SetActive(true);
        m_GameSceneController.EndOpening();
    }
}
