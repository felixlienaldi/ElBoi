using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoueManager : MonoBehaviour {
    private Queue<string> sentences;
    public Text dialogouetext;
    public GameObject obsject;
    public AudioSource start;
    public AudioSource start2;
    //public Animator animator;

    // Use this for initialization
    void Awake()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {

    }

    public void StartDialogoue(Dialogoue dialogue) {
      
        sentences.Clear();
       // animator.SetBool("IsOpen", true);

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(sentences.Count == 0)
        {
            EndDialogoue();
            obsject.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            start.Pause();
            start2.Play();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogouetext.text = sentence;
        StopAllCoroutines();
        StartCoroutine(typesentence(sentence));
    }

    IEnumerator typesentence(string sentence) {
        dialogouetext.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogouetext.text += letter;
            yield return null;
        }
 
        yield return new WaitForSecondsRealtime(5);
        DisplayNextSentence();
     
    }

    void EndDialogoue() {
       // animator.SetBool("IsOpen", false);
    }


}
