using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FREEZEY : MonoBehaviour {
    public Transform cam;
    public Vector2 target;

	// Use this for initialization
	void Start () {
       // transform.parent = null;

	}
	
	// Update is called once per frame
	void Update () {
     
	}

    public void moving(float speed,bool isMoving)
    {
        target.y =0;
        target.x += speed *Time.deltaTime;
        transform.Translate(target);
        isMoving = false;
    }
}
