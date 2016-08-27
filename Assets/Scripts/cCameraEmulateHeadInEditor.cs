using UnityEngine;
using System.Collections;

// Use mouse to emulate head.
public class cCameraEmulateHeadInEditor : MonoBehaviour
{
	public bool trackRotation = true;
    //[AutoGetComponent(AutoGetComponent.From.self)]
	[HideInInspector]
	public Transform target;

	#if UNITY_EDITOR// || UNITY_STANDALONE
	float mouseX = 0;
	float mouseY = 0;
	float mouseZ = 0;
	Quaternion rot;
	bool updatedHead;
    [Range(0,2)]
    public float speed = 0.1f;


    void Start ()
	{
		//Initialization.AddUpdateObj(updatePerFrame);
	}

	void Update()
	{
		updatePerFrame();
        Move();

    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * speed;
        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * speed;
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * speed;
        if (Input.GetKey(KeyCode.A))
            transform.position -= transform.right * speed;
        if (Input.GetKey(KeyCode.Space))
            transform.position += transform.up * speed;
        if (Input.GetKey(KeyCode.LeftShift))
            transform.position -= transform.up * speed;
    }


    private void updatePerFrame()
	{
		updatedHead = false;  // OK to recompute head pose.
		UpdateHead();
	}

	private void UpdateHead()
	{
		if (updatedHead)	// Only one update per frame.
			return;
		
		updatedHead = true;

		if (trackRotation)
		{
			mouseMovement();
			if (Input.GetMouseButtonDown (1))
			{
				mouseX = 0;
				mouseY = 0;
				mouseZ = 0;
				this.transform.rotation = Quaternion.identity;
			}
			else
			{
				if (target == null)
					this.transform.localRotation = rot;
				else
					this.transform.rotation = target.rotation * rot;
			}
		}
	}

	public void mouseMovement()
	{
		if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
		{
			mouseX += Input.GetAxis("Mouse X") * 5;
//			if (mouseX <= -180)
//				mouseX += 360;
//			else if (mouseX > 180)
//				mouseX -= 360;
			mouseY -= Input.GetAxis("Mouse Y") * 2.4f;
			mouseY = Mathf.Clamp(mouseY, -85, 85);
		}
		else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
		{
			mouseZ += Input.GetAxis("Mouse X") * 5;
			mouseZ = Mathf.Clamp(mouseZ, -85, 85);
		}
		rot = Quaternion.Euler(mouseY, mouseX, mouseZ);
	}
	#endif  
}
