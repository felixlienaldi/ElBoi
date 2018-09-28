using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour {
    public BossBehaviour boss;
    bool facing;
	// Use this for initialization
	void Start () {
        boss = GameObject.Find("entity_000").GetComponent<BossBehaviour>();
        facing = boss.facingRight;
        if (!facing)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);

        }
    }
	
	// Update is called once per frame
	void Update () {
        if (facing)
        {
           
            transform.Translate(20f * Time.deltaTime, 0f, 0f);
        }
        else
        {
            
            

            transform.Translate(-20f * Time.deltaTime, 0f, 0f);
        }
	}
}
