using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour {

   public bool notcd;
    [SerializeField]
    float cds;
    [SerializeField]
    float Duration;
    public Animator anim;
    Collider2D col;
    public ElementChange el;
    public BoiMovement boi;
	// Use this for initialization
	void Start () {
        notcd = true;
        col = GetComponent<Collider2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
            cds = 20f;
            if (Input.GetKey(KeyCode.D) && el.elementNum == 2)
            {
                if (notcd)
                {
                    Duration = 8f;
                    anim.SetBool("activate", true);
                    StartCoroutine(Bertahan());
                    col.enabled = true;

                }
                else
                {
                    anim.SetBool("activate", false);
                    col.enabled = false;
                }
            }

    }
    
    public IEnumerator cooldown()
    {
        yield return new WaitForSeconds(cds);
        notcd = true;
        
    }

    public IEnumerator Bertahan()
    {
        yield return new WaitForSeconds(Duration);
        anim.SetBool("activate", false);
        col.enabled = false;
        StartCoroutine(cooldown());
        notcd = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemyEarth")
        {
            anim.SetBool("activate", false);
            notcd = false;
            col.enabled = false;
            Destroy(collision.gameObject);
        }
    }
}
