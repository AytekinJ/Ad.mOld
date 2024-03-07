using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHasarYemeCollider : MonoBehaviour
{
public GameObject playerObject;
// public Transform particlePosition;
public GameObject bigCloud;
public GameObject bigRandomObjects;
public GameObject bigCloud2;
public GameObject bigRandomObjects2;
public GameObject bossCorpse;
public GameObject bossSceneManagear;
bool smashAttack;
bool destroyingStart;
int bossHealth = 2;
private void FixedUpdate() {
    if(destroyingStart && bossHealth <= 0)
    {
        bossSceneManagear.GetComponent<BossSceneManager>().skipSceneStart = true;
        bigCloud2.transform.position = new Vector2(transform.position.x, transform.position.y);
        bigCloud2.SetActive(true);
        bigRandomObjects2.transform.position = new Vector2(transform.position.x, transform.position.y);
        bigRandomObjects2.SetActive(true);
        bossCorpse.SetActive(true);
        gameObject.GetComponentInParent<BossDeneme2>().BossDeath();
        Destroy(bigCloud2, 1f);
        Destroy(bigRandomObjects2, 1f);
    }
    else if(destroyingStart)
    {
        bigCloud.transform.position = new Vector2(transform.position.x, transform.position.y);
        bigCloud.SetActive(true);
        bigRandomObjects.transform.position = new Vector2(transform.position.x, transform.position.y);
        bigRandomObjects.SetActive(true);
        gameObject.GetComponentInParent<BossDeneme2>().BossDamageAnim();
        Destroy(bigCloud, 1f);
        Destroy(bigRandomObjects, 1f);
        destroyingStart = false;
    }
}
private void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.CompareTag("Player") && smashAttack)
    {
        other.gameObject.GetComponent<Moving>().TransformingOther();
        bossHealth--;
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
