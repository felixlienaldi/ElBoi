using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Rigidbody2D))]
public class TestScript : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed;
    public Camera cam;
    private Vector3 targetPosition;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = cam.ScreenToWorldPoint(mousePosition);
        rb.MovePosition(mousePosition);

    }
}

