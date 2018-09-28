using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quater : MonoBehaviour {

    public Transform[] patrolPoints;
    public float speed;
    public Transform currentPatrolPoint;
    public Vector3 a;
   public int currentPatrolIndex;

    // Use this for initialization
    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f)
        {
            if (currentPatrolIndex + 1 < patrolPoints.Length)
                currentPatrolIndex++;
            else
                currentPatrolIndex = 0;
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
          
        }

              a = currentPatrolPoint.position - transform.position;
        Debug.Log(Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg);
            float angle = Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg - 360f;
        Debug.Log(angle);
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.up);
        Debug.Log(q);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 360f);

    }
}
