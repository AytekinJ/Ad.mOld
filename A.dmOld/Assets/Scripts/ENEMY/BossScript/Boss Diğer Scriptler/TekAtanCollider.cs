using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TekAtanCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerIntract>().healthNumber = 0;
            

        }
    }
}
