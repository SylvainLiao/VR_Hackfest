using UnityEngine;
using System.Collections;

public class ViveControllerHide : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(GetComponent<MeshRenderer>()!=null)
		GetComponent<MeshRenderer> ().enabled = false;
	
	}
	

}
