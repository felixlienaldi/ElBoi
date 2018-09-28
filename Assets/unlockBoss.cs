using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockBoss : MonoBehaviour {

    public DeathManager VictoryMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OntriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "PlayerArea")
        {
            VictoryMenu.Victory();
        }
    }
}
