using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardOnCollision : MonoBehaviour
{
    public Transform meeple;
    public GameObject speechbubble;
    public Animator anim;
    public AutoText autot;

    // Use this for initialization
    void Start()
    {

        meeple = this.gameObject.transform.GetChild(0);
        speechbubble = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        anim = GetComponentInChildren<Animator>();
        autot = GetComponentInChildren<AutoText>();
            }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D c)
    {

        if (c.gameObject.tag == "PlayerArea")
        {
            anim.SetBool("IsCollided", true);
            StartCoroutine(autot.TypeText(anim));
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerArea") {
            anim.SetBool("IsCollided", false);
            StartCoroutine(autot.TypeText(anim));
        }
    }





}
