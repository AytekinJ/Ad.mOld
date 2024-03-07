using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class OneArmMoving : MonoBehaviour
{
#region Movement Variables

    float pHorizontal;
    bool isFacingRight = true;

    #endregion
    
    public GameObject eButton;
    public float speed = 250f;
    Rigidbody2D rb;

    public bool readyToDestroy;
    public GameObject armObject;
    public GameObject PlayerObject;
    TestGameManager tgm;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        Flip();
        AnimationControls();
    }

    private void FixedUpdate() {
        Movement();
    }



    #region Movement Codes

    void Movement()
    {
        if(readyToDestroy)
        {
            transform.position = new Vector3(armObject.transform.position.x, transform.position.y);
            
            Destroy(gameObject, 1f);
            Destroy(armObject, 1f);
        }
        else
        {
            pHorizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(pHorizontal * speed * Time.deltaTime , rb.velocity.y);
        }
        
    }
    
    void Flip()
    {
        if(isFacingRight && pHorizontal < 0f || !isFacingRight && pHorizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            eButton.gameObject.GetComponent<SpriteRenderer>().flipX = !eButton.gameObject.GetComponent<SpriteRenderer>().flipX;
            transform.localScale = localScale;
        }
    }
    #endregion


    #region Animation Codes
    void AnimationControls()
    {
        animator.SetFloat("Horizontal", math.abs(pHorizontal));
    }
    #endregion



}
