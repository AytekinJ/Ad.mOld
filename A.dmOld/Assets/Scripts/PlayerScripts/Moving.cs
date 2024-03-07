using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Moving : MonoBehaviour
{
    #region Movement Variables

    float pHorizontal;
    bool groundCheck;
    bool isFacingRight = true;
    bool moveSlow;
    public float jumpPover = 10f;
    public float groundCheckRadius = .35f;
    public GameObject groundCheckPosition;
    public LayerMask groundCheckLayer;

    #endregion
    
    #region Animation Variables
    Animator animator;

    public bool isSmashing;
    #endregion
    
    #region Smash Variables
    public float speed = 250f;
    float currentSpeed;
    float decrasedSpeed;
    Rigidbody2D rb;

    float sayac;
    float sayac2 = 100;
    bool smashedFreeze;
    #endregion

    #region KnockBack Variables
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool knockFromRight;
    float realSpeed;
    #endregion
    public GameObject intractObbject;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        currentSpeed = speed;
        realSpeed = speed;
        decrasedSpeed = speed/1.5f;
    }

    
    void Update()
    {
        CheckSurfaceForMovement();
        Jump();
        Flip();
        AnimationControls();

        
    }

    private void FixedUpdate() {
        Movement();
    }



    #region Movement Codes

    void Movement()
    {
        if(moveSlow)
        {
            currentSpeed = decrasedSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
        
        if(KBCounter <= 0)
        {
            if(isSmashing)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            
                sayac2 = .6f;
                smashedFreeze = true;
            
            }
            else
            {
                pHorizontal = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(pHorizontal * currentSpeed * Time.deltaTime , rb.velocity.y);
            
            }
        }
        else
        {
            if(knockFromRight == true)
            {
                rb.velocity = new Vector2(KBForce, 0);
            }
            if(knockFromRight == false)
            {
                rb.velocity = new Vector2(-KBForce, 0);
            }
            
            KBCounter -= Time.deltaTime;
        }
        

        if(sayac2 < 0 && smashedFreeze)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            smashedFreeze = false;
        }
        sayac2 -= Time.deltaTime;
        
    }

    void CheckSurfaceForMovement()
    {
        groundCheck = Physics2D.OverlapCircle(groundCheckPosition.transform.position, groundCheckRadius, groundCheckLayer);
        
        
    }
    
    void Jump()
    {
        if(KBCounter <= 0)
        {
            if (groundCheck == true)
            {
            
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpPover);
                    sayac = 0.2f;
                    moveSlow = true;
                
                }

                sayac -= Time.deltaTime;

                if(sayac < 0)
                {
                    moveSlow = false;
                }
            }
        

            if(groundCheck == false && Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                isSmashing = true;
                rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y + -6f);
            }
            else if(groundCheck == true && sayac < 0)
            {
                isSmashing = false;
            }
        }
        
        
    }
    void Flip()
    {
        if(isFacingRight && pHorizontal < 0f || !isFacingRight && pHorizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            intractObbject.gameObject.GetComponent<SpriteRenderer>().flipX = !intractObbject.gameObject.GetComponent<SpriteRenderer>().flipX;
            transform.localScale = localScale;
        }
    }
    #endregion

    #region Gizmos
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPosition.transform.position, groundCheckRadius);
    }
    #endregion

    #region Animation Codes
    void AnimationControls()
    {
        animator.SetFloat("Horizontal", math.abs(pHorizontal));
        animator.SetBool("isSmash", isSmashing);
        animator.SetBool("isJump", !groundCheck);
        animator.SetFloat("KBCounter", KBCounter);
    }
    #endregion

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("wall"))
        {
            speed = 1;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("wall"))
        {
            speed = realSpeed;
        }
    }

    public void TransformingOther()
    {
        transform.position = new Vector3(-8.64f, -5.91f, 0);
    }

}
