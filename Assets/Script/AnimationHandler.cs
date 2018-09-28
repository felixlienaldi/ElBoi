using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {

    private Animator anim;
    public bool collided = false;
    private ElementChange el;
    Collider2D col;
    public Collider2D coll;
    
    // Use this for initialization
    void Start () {
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        el = GameObject.FindGameObjectWithTag("PlayerArea").GetComponent<ElementChange>();

        
    }
	
	// Update is called once per frame
	void Update () {
        if (collided)
        {
            anim.SetBool("Crack", true);
            col.enabled = false;
            coll.enabled = false;
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile" && el.elementNum == 2)
        {
            collided = true;
        }
    }
}
