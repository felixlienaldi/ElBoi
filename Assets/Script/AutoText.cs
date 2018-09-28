using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoText : MonoBehaviour {

    public float letterpause;
    public string message;
    public TextMesh textcomp;

	// Use this for initialization
	void Start () {
        textcomp = GetComponent<TextMesh>();
        message = textcomp.text;
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}

     public IEnumerator TypeText(Animator a) {
        textcomp.text = "";
        char[] letter = message.ToCharArray();
            for(int i =0; i< letter.Length; i++)
        {
            if (a.GetBool("IsCollided") == false) break;
            textcomp.text += letter[i];
            yield return new WaitForSeconds(0.025f);
        }
    }
}
