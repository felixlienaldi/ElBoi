using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSkill : MonoBehaviour {

    public ElementChange el;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "PlayerArea")
        {
            el.ElectricUnlock = true;
            Destroy(this.gameObject);
        }
    }
}
