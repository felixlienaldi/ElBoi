using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour {
	
    public GameObject player;
    public HeartSystem heart;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("PlayerArea");
        heart = player.GetComponent<HeartSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void givedamge(int damage) {
        Debug.Log("tes");
        heart.takedamage(damage);
    }
}
