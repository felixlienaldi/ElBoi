using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSystem : MonoBehaviour {
	public ElementChange el;
	public GameObject creature;
    public float damage;
    public BoiMovement boi;
    //0 api
    //1 air
    //2 tanah
    //3 listrik

    //Earth , thunder , water , fire

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SystemDamage(int element){
        
		if (element == 0) {
			if (el.elementNum == 1) {
				damage = Random.Range (3f, 5f) * Random.Range (1.5f, 2f);
			} else if(el.elementNum == 2){
				damage = Random.Range (3f, 5f) * Random.Range (0.5f, 0.7f);
			} else {
				damage = Random.Range (3f, 5f);
			}
		} else if (element == 1) {
			if (el.elementNum == 3) {
				damage = Random.Range (3f, 5f) * Random.Range (1.5f, 2f);
			} else if(el.elementNum == 0){
				damage = Random.Range (3f, 5f) * Random.Range (0.5f, 0.7f);
			} else {
				damage = Random.Range (3f, 5f);
			}
		} else if (element == 2) {
			if (el.elementNum == 0) {
				damage = 3f * Random.Range (1.5f, 2f);
			} else if(el.elementNum == 3){
				damage = 10f * boi.chargeTime;
            } else {
                damage = 3f;
			}
		} else if (element == 3) {
			if (el.elementNum == 2) {
			    damage = Random.Range (3f, 5f) * Random.Range (1.5f, 2f);
			} else if(el.elementNum == 1){
				damage = Random.Range (3f, 5f) * Random.Range (0.5f, 0.7f);
			} else {
                damage = 10f * boi.chargeTime;
			}
        } else if(element == 10)
        {
            damage = 10f;
        }
	}
}
