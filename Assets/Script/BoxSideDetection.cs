using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSideDetection : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col){
		
		foreach (ContactPoint2D hitObs in col.contacts) {
			Debug.Log (hitObs.normal);

		}
	}
}
