using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Movement Variables

    float pHorizontal;
    bool groundCheck;
    public float groundCheckRadius = .35f;
    public float jumpPover = 10f;
    public GameObject groundCheckPosition;
    public LayerMask groundCheckLayer;
    #endregion

    #region Wall Jumping Variables
    bool isWallSliding;
    float wallSlidingSpeed;

    bool isWallJumping;
    float wallJumpingDirection;
    float wallJumpingTime = 0.2f;
    float wallJumpingCounter;
    float wallJumpingDuration = 0.4f;
    Vector2 wallJumpingPower = new Vector2(8f, 16f);

    #endregion

    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask wallLayer;

    bool isFacingRight;
    
    public float speed = 10f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSurfaceForMovement();
        Jump();
        Wallslide();
        WallJump();

        if(!isWallJumping)
        {
            Flip();
        }
        
    }

    private void FixedUpdate() {
        Movement();

        if(!isWallJumping)
        {
            rb.velocity = new Vector2(pHorizontal * speed , rb.velocity.y);
        }
        
    }
    #region Movement Codes

    void Movement()
    {
        pHorizontal = Input.GetAxis("Horizontal");
        
    }
    void CheckSurfaceForMovement()
    {
        groundCheck = Physics2D.OverlapCircle(groundCheckPosition.transform.position, groundCheckRadius, groundCheckLayer);
        
    }
    void Jump()
    {
        if (groundCheck == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPover);
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPosition.transform.position, groundCheckRadius);
    }
    #endregion

    bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }
    #region Wall Slide/Jump Codes
    void Wallslide()
    {
        if(IsWalled() && groundCheck == false && pHorizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
            
        }
    }

    void WallJump()
    {
        if(isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump")&& wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDuration * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if(transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping),wallJumpingDirection);
        }
        
    }
    void StopWallJumping()
    {
        isWallJumping = false;       
    }
    #endregion

    void Flip()
    {
        if(isFacingRight && pHorizontal < 0f || !isFacingRight && pHorizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
