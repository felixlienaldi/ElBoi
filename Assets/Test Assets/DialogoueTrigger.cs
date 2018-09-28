using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoueTrigger : MonoBehaviour {

    public Dialogoue dialogoue;

    public void TriggerDialoue() {
        Debug.Log("a");
        FindObjectOfType<DialogoueManager>().StartDialogoue(dialogoue);
    }
}
