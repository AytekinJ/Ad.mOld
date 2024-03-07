using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TutorialGameManager : MonoBehaviour
{
 bool readyToCreate;
    public GameObject pplayer;
    public GameObject destroyedPlayer;
    public GameObject cloudObjectt;
 
    float sayac = 1;
    float sayac2 = 3;
    bool sayacAktif;

    #region Ayarlar
    public GameObject tutorialUI;
    public GameObject closeSettingsButton;
    int escCounter;
    #endregion

    #region Müzik Ayarları
    float muzikSayac;
    float muzikSayac2;
    public AudioSource dramaticMusic;
    public AudioSource whiteNoise;
    #endregion
    // Update is called once per frame
    void Update()
    {
        muzikSayac += Time.deltaTime * 0.25f;
        if(whiteNoise.volume < 0.08f)
        {
            whiteNoise.volume = muzikSayac;
        }

        muzikSayac2 += Time.deltaTime * 0.8f;
        if(dramaticMusic.volume < 0.02f)
        {
            dramaticMusic.volume = muzikSayac;
        }

        if(readyToCreate && sayac > 0)
        {
            sayac -= Time.deltaTime;
            Destroy(cloudObjectt, 2.5f);
        }
        else if(readyToCreate && sayac < 0)
        {
            pplayer.SetActive(true);
            sayac2 -= Time.deltaTime;
        }

        if(sayac2 < 0 && sayacAktif == false)
        {
       
            escCounter = 1;
            tutorialUI.SetActive(true);
            sayacAktif = true;
        }

        if(readyToCreate == false)
        {
            readyToCreate = destroyedPlayer.GetComponent<OneArmMoving>().readyToDestroy;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && escCounter <= 0)
        {
            tutorialUI.SetActive(true);
            escCounter = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && escCounter >= 1)
        {
            tutorialUI.SetActive(false);
            closeSettingsButton.SetActive(true);
            escCounter = 0;
        }
    }



    public void TutorialQuiting()
    {
        tutorialUI.SetActive(false);

    }
}
