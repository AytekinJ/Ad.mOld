using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapScript : MonoBehaviour
{   public GameObject cloudPopUp;
    public GameObject RandomParticles;
    public GameObject oilItem;
    public GameObject Pplayer;

    public bool smashAttack;

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") && smashAttack)
        {
            cloudPopUp.SetActive(true);
            RandomParticles.SetActive(true);
            oilItem.SetActive(true);
            Destroy(gameObject, 0.2f);
            Destroy(cloudPopUp, 1f);
            Destroy(RandomParticles, 1f);
        }
    }

    void Update()
    {   try
        {
            smashAttack = Pplayer.GetComponent<Moving>().isSmashing;
        }
        catch
        {

        }
        
    }
}
