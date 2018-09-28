using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class BoiMovement : MonoBehaviour
{

    [Range(1f, 10f)] public float speed;
    [Range(1f, 1000f)] public float jumpForce;
    private Rigidbody2D rb;
    public bool facingRight = false;
    [SerializeField] private LayerMask checkGround;
    private Transform GroundCheck;
    private bool IsGrounded;
    public bool isCollision;
    public Damaging dmg;
    public GameObject Projectile;
    public ElementChange el;
    public Animator anim;
    private bool move = false;
    private float waitTime;
    public float chargeTime;
    bool spam = true;
    public LayerMask layer;
    RaycastHit2D hit;
    private Transform Right;
    private Transform left;
    public float knock;
    public float FallMultiplier;
    public float lowJumpMultiplier;
    public Ability ab;
    [Space]
    public float blinkDistance;
    Vector3 blink;
    RaycastHit2D[] hits;
    Vector3 bestpoint;


    public bool throughWalls;
    public bool nearestPoint;
    public bool blink2D;
    public bool blinked;
    public bool cooldown = false;
    public float step = 0.2f;

    public float distance = 4f;
    public GameObject charged;

    public Text text;
    public float ff = 5f;

    // Use this for initialization
    private void Awake()
    {
        GameSystem.current = new GameSystem();
        SaveLoad.New();
    }

    void Start()
    {
        GroundCheck = transform.Find("GroundCheck");
        Right = transform.Find("Right");
        left = transform.Find("Left");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("walking", false);
        waitTime = 0.1f;
        Physics2D.queriesStartInColliders = false;
    }


    // Update is called once per frame  

    void Update()
    {

        knockback();
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }
    void FixedUpdate()
    {
        anim.SetBool("attack", false);
        anim.SetBool("walking", false);
        anim.SetBool("spell", false);
        anim.SetBool("Blink", false);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!facingRight)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            }
            anim.SetBool("walking", true);
            rb.velocity = new Vector2(speed, rb.velocity.y);

            facingRight = true;



        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (facingRight)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
            }
            anim.SetBool("walking", true);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            facingRight = false;


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] ray = Physics2D.OverlapCircleAll(GroundCheck.position, .4f, checkGround);
            for (int i = 0; i < ray.Length; i++)
            {
                if (ray[i].gameObject != gameObject)
                {

                    IsGrounded = true;
                }
            }

            if (IsGrounded == true)
            {
                anim.SetBool("jumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                IsGrounded = false;
                StartCoroutine(jumpingAnimation());
            }


        }



        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("spell", true);
            if (el.elementNum == 0)
            {
                Instantiate(Projectile.transform.GetChild(3).gameObject, transform.position, transform.rotation);
            }
            else if (el.elementNum == 2)
            {

                if (spam)
                {
                    StartCoroutine(delayProjectile());
                }
            }
            else if (el.elementNum == 3)
            {
                charged.SetActive(false);
                if (facingRight)
                {

                    if (chargeTime <= 1f)
                    {
                        Instantiate(Projectile.transform.GetChild(2).gameObject, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), transform.rotation);
                    }
                    if (chargeTime > 1f)
                    {
                        Instantiate(Projectile.transform.GetChild(2).gameObject, new Vector3(transform.position.x + 2.25f, transform.position.y, transform.position.z), transform.rotation);
                    }
                }
                else
                {

                    if (chargeTime <= 1f)
                    {
                        Instantiate(Projectile.transform.GetChild(2).gameObject, new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z), transform.rotation);

                    }
                    if (chargeTime > 1f)
                    {
                        Instantiate(Projectile.transform.GetChild(2).gameObject, new Vector3(transform.position.x - 2.25f, transform.position.y, transform.position.z), transform.rotation);
                    }
                }


            }
        }


        if (Input.GetKey(KeyCode.S))
        {

            if (el.elementNum == 1)
            {
                anim.SetBool("spell", true);
                if (facingRight)
                {
                    Instantiate(Projectile.transform.GetChild(0).gameObject, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), transform.rotation);
                }
                else
                {
                    Instantiate(Projectile.transform.GetChild(0).gameObject, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z), transform.rotation);
                }

            }
            if (el.elementNum == 3)
            {
                anim.SetBool("spell", true);
                chargeTime += Time.deltaTime;
                charged.SetActive(true);


            }
        }

        if (blinked)
        {
                if (!throughWalls)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, distance);
                    if (hit.collider == null || hit.collider.tag == "susu" || hit.collider.tag == "Spikes" || hit.collider.tag == "enemyEarth" ||hit.collider.tag =="Boss")
                    {
                        transform.position += transform.localScale.x * Vector3.right * distance;

                    }
                    else
                    {
                        transform.position = hit.point;

                    }
                }
                else
                {
                    if (!Physics2D.OverlapPoint(transform.position + transform.localScale.x * Vector3.right * distance))
                    {
                        transform.position += transform.localScale.x * Vector3.right * distance;
                    }
                    else if (!nearestPoint)
                    {
                        hits = Physics2D.RaycastAll(transform.position, transform.localScale.x * Vector2.right, distance);


                        bestpoint = hits[0].point;
                        foreach (RaycastHit2D h in hits)
                        {
                            if (h.distance > Vector2.Distance(bestpoint, transform.position) &&
                               !Physics2D.OverlapPoint(h.point + h.normal * .3f))
                            {
                                bestpoint = h.point;
                            }
                        }

                        transform.position = bestpoint;


                    }
                    else if (nearestPoint)
                    {
                        if (!blink2D)
                        {
                            hits = Physics2D.RaycastAll(transform.position, transform.localScale.x * Vector2.right, distance);


                            bestpoint = hits[0].point;
                            foreach (RaycastHit2D h in hits)
                            {
                                if (h.distance > Vector2.Distance(bestpoint, transform.position) &&
                                   !Physics2D.OverlapPoint(h.point + h.normal * .3f))
                                {
                                    bestpoint = h.point;
                                }
                            }
                            Vector3 aux = bestpoint;
                            while (Physics2D.OverlapPoint(aux))
                            {
                                aux += step * Vector3.right * transform.localScale.x;
                            }

                            if (Vector2.Distance(aux, transform.position + transform.localScale.x * Vector3.right * distance) < Vector2.Distance(bestpoint, transform.position + transform.localScale.x * Vector3.right * distance))
                                bestpoint = aux;


                            transform.position = bestpoint;

                        }
                        else if (blink2D)
                        {

                            bestpoint = transform.position;
                            Vector2 aux;
                            for (aux.x = transform.position.x + transform.localScale.x * distance - distance; aux.x < transform.position.x + transform.localScale.x * distance + distance; aux.x += step)
                            {

                                for (aux.y = transform.position.y - distance; aux.y < transform.position.y + distance; aux.y += step)
                                {

                                    if (Vector2.Distance(aux, transform.position + transform.localScale.x * Vector3.right * distance) < Vector2.Distance(bestpoint, transform.position + transform.localScale.x * Vector3.right * distance)
                                       && !Physics2D.OverlapPoint(aux))
                                    {
                                        bestpoint = aux;
                                    }
                                }

                            }
                            transform.position = bestpoint;


                        }

                    



                    }
                }
          
            cooldown = true;
            StartCoroutine(CoolDownl());
           
        }


        if (Input.GetKeyDown(KeyCode.D) && el.elementNum == 3)
        {
            /* if (facingRight)
       {
           anim.SetBool("Blink", true);
           blink = new Vector3(blinkDistance, 0f, 0f);
           StartCoroutine(blinsk());

       }
       else
       {
           anim.SetBool("Blink", true);
           blink = new Vector3(-blinkDistance, 0f, 0f);
           StartCoroutine(blinsk());
       }*/
            if (!cooldown)
            {
                anim.SetBool("Blink", true);
                StartCoroutine(blinke());
               
            }
         

          
        }

        if (cooldown)
        {
            ff -= Time.deltaTime;
           
        }
        text.text = "" + Mathf.Round(ff);
        if(ff<1 && !cooldown)
        {
            ff = 5f;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;


        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * distance);


        /*foreach (RaycastHit2D h in hits) {
			Gizmos.DrawWireSphere(h.point,0.2f);
			Gizmos.DrawLine(h.point,h.point+h.normal*.3f);
				}
		Gizmos.color = Color.yellow;*/
        Gizmos.DrawWireSphere(bestpoint, 0.2f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "bossAttack")
        {
            dmg.givedamge(1);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle ice" || collision.gameObject.tag == "obstacle crystal" || collision.gameObject.tag == "obstacle boulder")
        {
            isCollision = true;
        }
        if (collision.gameObject.tag == "obstacle fire")
        {
            dmg.givedamge(1);
            isCollision = true;
        }
        if (collision.gameObject.tag == "enemyEarth")
        {
            foreach (ContactPoint2D hitObs in collision.contacts)
            {

                Debug.Log(hitObs.normal);
                if (hitObs.normal.x < 0)
                {
                    if (facingRight)
                    {
                        dmg.givedamge(1);
                        rb.velocity = new Vector2(-knock, 0f);

                    }
                    else if (!facingRight)
                    {
                        dmg.givedamge(1);
                        rb.velocity = new Vector2(-knock, 0f);
                        facingRight = true;
                        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                    }
                }
                else if (hitObs.normal.x > 0)
                {
                    if (facingRight)
                    {
                        dmg.givedamge(1);
                        rb.velocity = new Vector2(knock, 0f);
                        facingRight = false;
                        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);

                    }
                    else if (!facingRight)
                    {
                        dmg.givedamge(1);
                        rb.velocity = new Vector2(knock, 0f);

                    }
                }
            }
        }
        if (collision.gameObject.tag == "Spikes")
        {
            Debug.Log("kena");
            dmg.givedamge(6);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle ice" || collision.gameObject.tag == "obstacle crystal" || collision.gameObject.tag == "obstacle boulder" || collision.gameObject.tag == "obstacle fire")
        {
            isCollision = false;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            isCollision = false;

        }


    }


    public IEnumerator delayProjectile()
    {
        spam = false;
        int count = 3;
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(Projectile.transform.GetChild(1).gameObject, transform.position, transform.rotation);
            if (i == 2)
            {
                spam = true;
            }
        }

    }

    public void knockback()
    {


        Collider2D[] rayJump = Physics2D.OverlapCircleAll(GroundCheck.position, .2f, layer);
        for (int i = 0; i < rayJump.Length; i++)
        {
            if (rayJump[i].gameObject != gameObject)
            {
                dmg.givedamge(1);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            }

        }


    }
    

    public IEnumerator CoolDownl()
    {
        blinked = false;
        yield return new WaitForSeconds(5f);
        cooldown = false;
    }
    public IEnumerator jumpingAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("jumping", false);
    }

    public IEnumerator blinke()
    {
        yield return new WaitForSeconds(0.75f);
        blinked = true;
    }

}

