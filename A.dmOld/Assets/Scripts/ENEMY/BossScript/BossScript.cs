using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    #region Animation Variables

    #endregion

    #region KnockBack For Player

    public GameObject playerObject;
    #endregion
    
    public Transform point1;
    public Transform point2;
    public Transform jumpPoint;
    bool reachedPoint2;

    // float speed = 300;
    // int fazeCounter = 1;
    float jumpCoolDown;
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {

        jumpCoolDown -= Time.deltaTime;
    }
    private void FixedUpdate() {
        if(transform.position.x < jumpPoint.position.x && jumpCoolDown < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            jumpCoolDown = 5f;
            animator.SetFloat("Horizontal", 0);
        }

        if(jumpCoolDown > 0)
        { 
            if(transform.position.x < point2.position.x && reachedPoint2 == false)
            {
                transform.position += new Vector3(5f * Time.deltaTime, 0, 0);
                sr.flipX = true;
                animator.SetFloat("Horizontal", 1f);
            }
            else if(transform.position.x > point1.position.x)
            {
                reachedPoint2 = true;
                transform.position -= new Vector3(5f * Time.deltaTime, 0, 0);
                sr.flipX = false;
                animator.SetFloat("Horizontal", 1f);

            }
            else
            {
                reachedPoint2 = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            playerObject.GetComponent<Moving>().KBCounter = playerObject.GetComponent<Moving>().KBTotalTime;
            if(other.transform.position.x <= transform.position.x)
            {
                playerObject.GetComponent<Moving>().knockFromRight = false;
                // reachedB = false;
                // playerObject.GetComponent<PlayerIntract>().healthNumber--;
            }
            if(other.transform.position.x > transform.position.x)
            {
                playerObject.GetComponent<Moving>().knockFromRight = true;
                // reachedB = true;
                // playerObject.GetComponent<PlayerIntract>().healthNumber--;
            }
        }
    }
    void BossJumping()
    {

    }
}
