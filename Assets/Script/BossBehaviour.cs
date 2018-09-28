using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour {

    [Header ("Distance")]
    public float range;
    public float MaxDistance;//menentukan jarak terjauh dia ngejer
    public float MinDistance;
    public Transform target;
    public bool facingRight;
    public float direction;
    public float detection;
    [Space]

    [Header ("Attribute")]
    public float hp = 200f;
    public float speed;
    public bool detected = false;
    public bool delayed;
    public float attackTimer = 2f;
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject projectile;
    public ElementSystem el;
    public GameObject victory;

    void Start () {
        facingRight = false;
        delayed = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }


    //If close = random number for scratch and ground attack ( yg tangan masuk ke bawah )

    //If far = random number for ground dive, lunge, or ground attack
    void FixedUpdate()
    {
        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }
        
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            victory.SetActive(true);
            
        }

        anim.SetBool("RangeAttack", false);
        anim.SetBool("Attack", false);
        range = Mathf.Abs(target.position.x - transform.position.x);
        direction = target.position.x - transform.position.x;

        if (range < detection)
        {
            detected = true;
        }

        if (detected)
        {
                if (range >= MaxDistance)
                {
                    //attackScript
                    if(attackTimer <= 0.5f)
                {
                    anim.SetBool("RangeAttack", true);
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    attackTimer = 2f;
                }
                    
                    
                }
                else if (range <= MaxDistance)
                {
                    if (direction >= 0)
                    {
                        if (!facingRight)
                        {
                            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                            facingRight = true;

                        }
                        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, 0f);
                    }
                    else
                    {
                        if (facingRight)
                        {
                            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                            facingRight = false;

                        }
                        rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0f);

                    }
                }

                if (range <= MinDistance)
                {
                //meleeAttack;
                if (attackTimer <= 0.5f)
                {
                    anim.SetBool("Attack", true);
                    attackTimer = 2f;
                }
            }

                }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            el.SystemDamage(2);
            hp -= el.damage;
        }
        else if (col.gameObject.tag == "Sword")
        {
            el.SystemDamage(10);
            hp -= el.damage;

        }


    }

}





