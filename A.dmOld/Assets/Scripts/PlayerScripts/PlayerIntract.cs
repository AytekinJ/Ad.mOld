using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIntract : MonoBehaviour
{
    public GameObject pressEButton;
    public GameObject OilObject;
    float sayac;
    public GameObject deathCloud;
    public GameObject RandomGears;
    public float healthNumber = 2;
    public Image nail1;
    public Image nail2;
    public Image nail3;
    public Text point;

    public GameObject youLosedScreen;
    public GameObject blackFilter;

    public GameObject testSceneGameManager;
    bool buttonActived;

    public AudioSource potSound;

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
                healthNumber += 1;
                Destroy(OilObject);
                potSound.gameObject.SetActive(true);
            }
        }
        

        if(healthNumber > 3)
        {
            
            
        }
        else if(healthNumber == 3)
        {
            nail1.gameObject.SetActive(true);
            nail2.gameObject.SetActive(true);
            nail3.gameObject.SetActive(true);

        }
        else if(healthNumber == 2)
        {
            nail1.gameObject.SetActive(true);
            nail2.gameObject.SetActive(true);
            nail3.gameObject.SetActive(false);
        }
        else if(healthNumber == 1)
        {
            nail1.gameObject.SetActive(true);
            nail2.gameObject.SetActive(false);
            nail3.gameObject.SetActive(false);
        }
        else{

            nail1.gameObject.SetActive(false);
            nail2.gameObject.SetActive(false);
            nail3.gameObject.SetActive(false);

            try
            {
                testSceneGameManager.GetComponent<Scene3SScript>().reloadingScreen = true;
            }
            catch{
                testSceneGameManager.GetComponent<BossSceneManager>().ScreenReload();
            }

            deathCloud.transform.position = new Vector2(transform.position.x, transform.position.y);
            deathCloud.SetActive(true);
            RandomGears.transform.position = new Vector2(transform.position.x, transform.position.y);
            RandomGears.SetActive(true);
            Destroy(gameObject, 0.2f);
            Destroy(deathCloud, 1f);
            Destroy(RandomGears, 1f);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Oil"))
        {
            pressEButton.SetActive(true);
            buttonActived = true;
        
            sayac = 0.1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.CompareTag("FallDamageGround"))
        {
            healthNumber--;
            if(healthNumber > 0)
            transform.position = new Vector3(testSceneGameManager.transform.position.x, testSceneGameManager.transform.position.y);
        }
        
    }
  
}
