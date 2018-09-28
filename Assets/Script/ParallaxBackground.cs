using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Renderer))]
[RequireComponent (typeof(BoiMovement))]
public class ParallaxBackground : MonoBehaviour {
    [Range(0f, 1f)]
    [SerializeField]private float speed;
    public Transform target;
    

    private BoiMovement boi;
    // Use this for initialization
    void Start () {
        boi = GameObject.Find("Boi").GetComponent<BoiMovement>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
         Vector2 offset = new Vector2(transform.position.x * speed , 0f);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
        if (!boi.isCollision)
        {
            Vector3 newPos = target.position;
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }
       

}
