using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour {

    public Collider2D col;
    private bool attacking = false;
    [SerializeField]private float lala;
    public BoiMovement boi;
 
    
    
    void Start()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
        boi = GameObject.Find("Boi").GetComponent<BoiMovement>();
       
    }
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.A) && !attacking)
        {
            boi.anim.SetBool("attack", true);
            attacking = true;
            col.enabled = true;
            StartCoroutine(Wait());
        }
      
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag != "Player")
        {
            Debug.Log("Kena");
        }  
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(lala);
        attacking = false;
        col.enabled = false;
        boi.anim.SetBool("attack", false);

    }

}
