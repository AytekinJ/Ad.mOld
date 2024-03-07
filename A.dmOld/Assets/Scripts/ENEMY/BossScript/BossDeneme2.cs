using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BossDeneme2 : MonoBehaviour
{
    public GameObject playerObject;
    public Transform Apoint;
    public Transform Bpoint;
    bool ANoktasinaUlasildi;
    float jumpingCoolDown;
    bool onAiring = true;
    float speed = 3f;
    float sayac = 0.02f;
    bool takingDamageBoss = false;
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpingCoolDown -= Time.deltaTime;
    }

    private void FixedUpdate() {  
        

        if(sayac > 0.03f && takingDamageBoss)
        {
            sayac -= Time.deltaTime;
        }
        else
        {
            animator.SetBool("Damage", false);
            BossMovoement();
        }
        // if(takingDamageBoss == false)
        // {
            
        // }

        // if(sayac > 0 && takingDamageBoss)
        // {
        //     sayac -= Time.deltaTime;
        //     if(sayac < 0.1)
        //     {
        //         takingDamageBoss = false;
        //         animator.SetBool("Damage", false);
        //     }
        // }
    }

    void BossMovoement()
    {
        if(ANoktasinaUlasildi == false)
        {
            if(transform.position.x > Apoint.position.x)
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0,0);
                animator.SetFloat("Horizontal", 1);
                sr.flipX = false;
            }
            else if(jumpingCoolDown < 0)
            {
                animator.SetFloat("Horizontal", 0);
                BossJump();
            }
        }
        else if(ANoktasinaUlasildi)
        {
            if(transform.position.x < Bpoint.position.x)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0,0);
                animator.SetFloat("Horizontal", 1);
                sr.flipX = true;

            }
            else if(jumpingCoolDown < 0)
            {
                animator.SetFloat("Horizontal", 0);
                BossJump();
            }
        }
    }

    void BossJump()
    {
        if(transform.position.y < 9.5f && onAiring)
        {
            rb.velocity = new Vector2(rb.velocity.x, 7f);
            animator.SetBool("isJumped", true);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -40f);
            animator.SetBool("isJumped", false);
            if(transform.position.y < 1)
            {
                ANoktasinaUlasildi = !ANoktasinaUlasildi;
                onAiring = true;
            }
        }

        if(transform.position.y > 9.4f)
        {
            onAiring = false;
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            playerObject.GetComponent<Moving>().KBCounter = playerObject.GetComponent<Moving>().KBTotalTime * 2;
            if(other.transform.position.x <= transform.position.x)
            {
                playerObject.GetComponent<Moving>().knockFromRight = false;
                playerObject.GetComponent<PlayerIntract>().healthNumber--;
                // reachedB = false;
            }
            if(other.transform.position.x > transform.position.x)
            {
                playerObject.GetComponent<Moving>().knockFromRight = true;
                playerObject.GetComponent<PlayerIntract>().healthNumber--;
                // reachedB = true;
            }
        }
    }

    public void BossDeath()
    {
        Destroy(gameObject, .2f);
    }
    public void BossDamageAnim()
    {   
        takingDamageBoss = true;
        sayac = 1f;
        animator.SetBool("Damage", true);

    }
}
