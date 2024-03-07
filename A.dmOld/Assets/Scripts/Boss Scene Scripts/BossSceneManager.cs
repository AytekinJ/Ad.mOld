using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossSceneManager : MonoBehaviour
{
    public Image nail1, nail2, nail3;
    public GameObject YouLosedScreen;
    public GameObject BlackFilter;

    float sayac = 3f;
    public bool skipSceneStart = false;
    public void ReloadScene4()
    {
        SceneManager.LoadScene(4);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(5);
        }
    }

    public void DirectlySkipScene()
    {
        skipSceneStart = true;
        if(sayac < 0)
        {
            SceneManager.LoadScene(5);
        }
        
    }

    public void ScreenReload()
    {
        YouLosedScreen.SetActive(true);
        nail1.gameObject.SetActive(false);
        nail2.gameObject.SetActive(false);
        nail3.gameObject.SetActive(false);
        BlackFilter.SetActive(true);
    }

    private void Update() {
        if(skipSceneStart == true)
        {
            sayac -= Time.deltaTime;
        }
        
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(5);
        }
    }
}
