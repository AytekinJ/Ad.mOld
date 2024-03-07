using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2movement : MonoBehaviour
{
    #region Movement Variables

    float pHorizontal;
    bool groundCheck;
    bool isFacingRight;
    public float jumpPover = 10f;
    public float groundCheckRadius = .35f;
    public GameObject groundCheckPosition;
    public LayerMask groundCheckLayer;

    #endregion

    #region Wall Fall/Slide Variables
    

    bool wallFallCounter;

    bool wallCheck;

    public float wallCheckRadius = .35f;
    public LayerMask wallLayer;
    public GameObject wallCheckPosition;
    

    float sayac;
    #endregion
    
    
    public float speed = 250f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckSurfaceForMovement();
        Jump();
        Flip();

        

        if(wallFallCounter == true)
        {
            sayac -= Time.deltaTime;
        }
        else{
            sayac = 1;
            speed = 300f;
        }
        
    }
    private void FixedUpdate() {
        Movement();
    }

    #region Movement Codes

    void Movement()
    {
        pHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(pHorizontal * speed * Time.deltaTime , rb.velocity.y);
        
        // if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && groundCheck == true){
        //     transform.position += new Vector3(-speed *Time.deltaTime , 0, 0);
        // }
        // else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && groundCheck == false){
        //     transform.position += new Vector3(-speed  * 0.5f * Time.deltaTime, 0, 0);
        // }

        // if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && groundCheck == true){
        //     transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        // }
        // else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && groundCheck == false){
        //     transform.position += new Vector3(speed * 0.5f * Time.deltaTime, 0, 0);
        // }

        
    }

    void CheckSurfaceForMovement()
    {
        groundCheck = Physics2D.OverlapCircle(groundCheckPosition.transform.position, groundCheckRadius, groundCheckLayer);
        wallCheck = Physics2D.OverlapCircle(wallCheckPosition.transform.position, wallCheckRadius, wallLayer);
        
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

        if (wallCheck == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow))
            {
                if(isFacingRight)
                rb.velocity = new Vector2(-10f, jumpPover);
                else
                rb.velocity = new Vector2(10f, jumpPover);
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckPosition.transform.position, groundCheckRadius);
        Gizmos.DrawWireSphere(wallCheckPosition.transform.position, wallCheckRadius);
    }

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
    #endregion

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("wall"))
        {
            
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        
        if(other.gameObject.CompareTag("wall"))
        {
            wallFallCounter = true;
            if(sayac < 0)
            {
                speed = 1f;
            }
        }
        else
        {
            wallFallCounter = false;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("wall"))
        {
            wallFallCounter = false;
            print(wallFallCounter);
        }
    }

    
    
}
