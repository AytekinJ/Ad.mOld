using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMovingScript : MonoBehaviour
{
    float sayac = .7f;

    private void Update() {
        sayac -= Time.deltaTime;

        if(sayac > 0)
        {
            transform.position += new Vector3(0, 1f * Time.deltaTime ,0);
        }
        else
        {
            transform.position -= new Vector3(0, 1f * Time.deltaTime ,0);
        }

        if(sayac < -.7f)
        {
            sayac = .7f;
        }
    }
}
