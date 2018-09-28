using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementChange : MonoBehaviour {

    public Image elementUI;
    public Sprite[] ElementSprite;
    public int elementNum = 2;
    public bool active;
    public bool ElectricUnlock = false;
    //0 api
    //1 tanah
    //2 listrik
    //3 air

    // Use this for initialization
    void Start () {
        active = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (ElectricUnlock) {
            if (Input.GetKeyDown(KeyCode.Q) && active)
            {
                StartCoroutine(wait());
                Elementchange();
                active = false;
            }
        }
     
    }

    void Elementchange()
    {
        elementNum++;
        if (elementNum >= 4) elementNum = 2;
        elementUI.sprite = ElementSprite[elementNum];
    }
    
    public IEnumerator wait(){
        yield return new WaitForSeconds(0.5f);
        active = true;
    }
}
