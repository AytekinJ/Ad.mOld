using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene3SScript : MonoBehaviour
{   
    float sayac = 1.5f;
    float sayac2 = 10f;
    public bool reloadingScreen;
    public GameObject youLosedScreen;
    public GameObject blackFilter;
    public void ReloadScene()
    {
        SceneManager.LoadScene(3);
    }

    private void Update() {
        if(reloadingScreen)
        {
            sayac -= Time.deltaTime;
            if(sayac < 0)
            {
                youLosedScreen.SetActive(true);
                blackFilter.SetActive(true);
            }
        }

        sayac2 -= Time.deltaTime;
        Debug.Log(sayac2);
    }
}
