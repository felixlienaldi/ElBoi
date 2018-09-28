using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {
    public ElementChange el;
    
    public float speedPrj;
    public float waitTime;
    public GameObject player;
    public BoiMovement boi;
    public bool facing;
    private int counter =0;
    public Animator anim;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("PlayerArea");
        boi = player.GetComponent<BoiMovement>();
        el = player.GetComponent<ElementChange>();
        facing = boi.facingRight;
    }
    
	
	// Update is called once per frame
	void FixedUpdate () {
        el.active = false;
        if (el.elementNum == 1)
        {
            waitTime = 0.2f;
            StartCoroutine(WaitAndPoof());
            if (facing == false)
            {
                transform.Translate(-speedPrj * Time.fixedDeltaTime, 0f, 0f);
            }
            else
            {
                transform.Translate(speedPrj * Time.fixedDeltaTime, 0f, 0f);
            }
        }else if(el.elementNum == 3)
        {
            waitTime = 0.5f;
            if (!facing)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                facing = true;
            }
            
                if (boi.chargeTime > 1f)
                {
                    anim.SetBool("Charge", true);
                    StartCoroutine(WaitAndPoof());
                }
                else if (boi.chargeTime <= 1f)
                {
                    anim.SetBool("Charge1", true);
                    StartCoroutine(WaitAndPoof());
                }
          
        }
        else
        {
            waitTime = 0.5f;
            StartCoroutine(WaitAndPoof());
            if (facing == false)
            { 
                transform.Translate(-speedPrj * Time.fixedDeltaTime, 0f, 0f);
            }
            else
            {
                transform.Translate(speedPrj * Time.fixedDeltaTime, 0f, 0f);
            }
        }
	}

	void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "enemyEarth")
        {
            if(el.elementNum == 3)
            {

            }
            else
            {
                el.active = true;
                Destroy(this.gameObject);
            }
        }else if(col.gameObject.tag == "Boss")
        {
            if (el.elementNum == 3)
            {

            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else if (col.gameObject.tag == "obstacle ice" && el.elementNum == 0)
        {
            el.active = true;
            Destroy(this.gameObject);
            col.gameObject.SetActive(false);
            boi.isCollision = false;
        }
        else if (col.gameObject.tag == "obstacle fire" && el.elementNum == 1)
        {
            el.active = true;
            Destroy(this.gameObject);
            Destroy(col.gameObject);
            boi.isCollision = false;
        } else if (col.gameObject.tag == "obstacle crystal" && el.elementNum == 3)		
		{
            el.active = true;
            col.gameObject.SetActive(false);
            boi.isCollision = false;
        } else if (col.gameObject.tag == "obstacle boulder" && el.elementNum == 2)
		{
            el.active = true;
            Destroy(this.gameObject);
            boi.isCollision = false;
        }
    }

	public IEnumerator WaitAndPoof (){
		yield return new WaitForSeconds(waitTime);
        boi.chargeTime = 0;
        el.active = true;


        Destroy(this.gameObject);
       
    }
}
