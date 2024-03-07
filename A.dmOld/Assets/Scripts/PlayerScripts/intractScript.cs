using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intractScript : MonoBehaviour
{
    public GameObject pressEButton;
    public GameObject cloudObj;
    float sayac;

    bool buttonActived;
    void Start()
    {
        
    }
    private void Update() {
        sayac -= Time.deltaTime;
        if(sayac < 0)
        {
            pressEButton.SetActive(false);
            buttonActived = false;
        }

        if(buttonActived)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                cloudObj.SetActive(true);
                GetComponentInParent<OneArmMoving>().readyToDestroy = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Arm"))
        {
            pressEButton.SetActive(true);
            buttonActived = true;
            sayac = 0.1f;
        }
        
    }
    
}
