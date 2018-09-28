using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownText : MonoBehaviour {
    public Text text;
    public float aku =20f;
    public Ability ab;
	// Use this for initialization
	void Start () {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (ab.notcd == false)
        {
            aku -= Time.deltaTime;
        }
            text.text = "" + Mathf.Round(aku);
            if (aku < 1 && ab.notcd == true )
            {
                aku = 20f;
            }
       


    }
    
}

