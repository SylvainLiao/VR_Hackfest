using UnityEngine;
using System.Collections;

public class GameSceneController : MonoBehaviour {
    public GameObject OpeningAnimationRoot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartOpening()
    {
        OpeningAnimationRoot.SetActive(true);
    }

    public void EndOpening()
    {

    }
}
