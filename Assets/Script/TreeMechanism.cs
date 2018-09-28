using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMechanism : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public Transform target;
    private bool Chopped;
    [SerializeField]private int count;
	// Use this for initialization
	void Start () {
        Chopped = false;
        rb = GetComponent<Rigidbody2D>();
        count = 0;
    }
	
	// Update is called once per frame
	void Update () {
         if (Chopped && count >= 2)
            {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, speed * Time.deltaTime );

            }
        
        

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Sword")
        {
            count++;
            Chopped = true;
           
        }
    }
}
