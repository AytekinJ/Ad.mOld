using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform A,B;
    public bool reachedB;
    bool smashAttack;
    bool destroyingStart;
    public GameObject playerObject;
    public GameObject smallCloud;
    public GameObject RandomObjects;
    SpriteRenderer sr;
    
    private void Start() {
        sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate() {
        if(destroyingStart)
        {   
            smallCloud.transform.position = new Vector2(transform.position.x, transform.position.y);
            smallCloud.SetActive(true);
            RandomObjects.transform.position = new Vector2(transform.position.x, transform.position.y);
            RandomObjects.SetActive(true);
            Destroy(gameObject, 0.2f);
            Destroy(smallCloud, 1f);
            Destroy(RandomObjects, 1f);
        }
        else
        {

            if(transform.position.x < B.position.x && reachedB == false)
            {
                transform.position += new Vector3(7f * Time.deltaTime, 0, 0);
                sr.flipX = false;
            }
            else if(transform.position.x > A.position.x)
            {
                reachedB = true;
                transform.position -= new Vector3(7f * Time.deltaTime, 0, 0);
                sr.flipX = true;

            }
            else
            {
                reachedB = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") && smashAttack == false)
        {
            playerObject.GetComponent<Moving>().KBCounter = playerObject.GetComponent<Moving>().KBTotalTime;
            if(other.transform.position.x <= transform.position.x)
            {
                playerObject.GetComponent<Moving>().knockFromRight = false;
                reachedB = false;
                playerObject.GetComponent<PlayerIntract>().healthNumber--;
            }
            if(other.transform.position.x > transform.position.x)
            {
                playerObject.GetComponent<Moving>().knockFromRight = true;
                reachedB = true;
                playerObject.GetComponent<PlayerIntract>().healthNumber--;
            }
        }

        if(other.gameObject.CompareTag("Player") && smashAttack)
        {
            destroyingStart = true;
        }
    }

    void Update()
    {

        try
        {
            smashAttack = playerObject.GetComponent<Moving>().isSmashing;
        }
        catch
        {
            
        }
        
    }

}
