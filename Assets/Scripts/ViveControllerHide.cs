using UnityEngine;
using System.Collections;

public class ViveControllerHide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer> ().enabled = false;
	
	}
	

}
