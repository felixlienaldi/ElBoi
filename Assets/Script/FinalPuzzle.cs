using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzle : MonoBehaviour {
    public Animator ani;
    public GameObject player;
    public ElementChange el;
    public float time;
    public GameObject vict;
    public DeathManager vic;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("PlayerArea");
        el = player.GetComponent<ElementChange>();
        ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ani.GetBool("IsMelted") == true && (ani.GetInteger("Power Up") < 6)) { 
        if (ani.GetInteger("Power Up") < 0) {
                ani.SetInteger("Power Up", 0);
            }
            time += Time.deltaTime;
            if (time > 10)
            {
                ani.SetInteger("Power Up", ani.GetInteger("Power Up") - 1);
                time = 0;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projectile") {
            if (el.elementNum == 0)
            {
                ani.SetBool("IsMelted", true);
            }
            else if (el.elementNum == 3 && ani.GetBool("IsMelted") == true)
            {
                if (ani.GetInteger("Power Up") == 0)
                {
                    ani.SetInteger("Power Up", 1);
                    time = 0;
                }
                else if (ani.GetInteger("Power Up") == 1)
                {
                    ani.SetInteger("Power Up", 2);
                    time = 0;
                }
                else if (ani.GetInteger("Power Up") == 2)
                {
                    ani.SetInteger("Power Up", 3);
                    time = 0;
                }
                else if (ani.GetInteger("Power Up") == 3)
                {
                    ani.SetInteger("Power Up", 4);
                    time = 0;
                }
                else if (ani.GetInteger("Power Up") == 4)
                {
                    ani.SetInteger("Power Up", 5);
                    time = 0;
                }
                else if (ani.GetInteger("Power Up") == 5)
                {
                    ani.SetInteger("Power Up", 6);
                    ani.SetBool("Breakable", true);
                    time = 0;
                }
            }
            else if (el.elementNum == 2 && ani.GetBool("Breakable") == true) {
                Destroy(this.gameObject);
                vict.SetActive(true);
                
            }
            Destroy(col.gameObject);
        }
    }



}
