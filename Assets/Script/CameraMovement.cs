using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
	public bool cameraMovement = true;
	public Vector3 offset;
    private BoiMovement boi;
    private void Start()
    {
        boi = GameObject.Find("Boi").GetComponent<BoiMovement>();
    }

    // Update is called once per frame
    void LateUpdate() {
		
		if (!boi.isCollision) {
			Vector3 newPos = target.position + offset;
			newPos.z = transform.position.z;
			transform.position = newPos;
		}
	

    }


}
