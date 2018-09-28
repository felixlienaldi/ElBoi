using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(Rigidbody2D))]
public class HomingAI : MonoBehaviour {

	public Transform target;
    public BoiMovement boi;
    public float health = 15f;
    public float speed = 5f;
	public float JumpSpeed =5f;
	public float range;
	private Rigidbody2D rb;
    public ElementSystem el;
    public float x;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("PlayerArea").transform;
		rb = GetComponent<Rigidbody2D> ();
        StartCoroutine(bolakBalik());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        rb.velocity = new Vector2(-speed, 0f);



    }

    public void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Projectile")
        {
            el.SystemDamage(2);
            health -= el.damage;
        }
        else if (col.gameObject.tag == "Sword")
        {
            el.SystemDamage(10);
            health -= el.damage;

        }


	}

    public IEnumerator bolakBalik()
    {
        yield return new WaitForSeconds(2f);
        speed *= -1;
        StartCoroutine(bolakBalik());
    }




}
