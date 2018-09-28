using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting : MonoBehaviour {
    public AudioSource start;
	// Use this for initialization
	void Start () {
        start.playOnAwake = true;
        FindObjectOfType<DialogoueTrigger>().TriggerDialoue();
	}
	
	// Update is called once per frame
	

}
