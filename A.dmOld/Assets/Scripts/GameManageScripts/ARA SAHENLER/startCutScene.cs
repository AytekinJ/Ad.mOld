using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startCutScene : MonoBehaviour
{
    public float sayac = 50;
    float sayac2;

    public Image oc_0, oc_1, oc_2, oc_3, oc_4;
    public Text storyText;

    // Update is called once per frame
    void Update()
    {
        sayac -= Time.deltaTime;
        sayac2 += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Return))
        {
            NextScene();
        }
    }
    private void FixedUpdate() {
        if(sayac < 49.1f && sayac > 46.5f)
        {
            oc_0.gameObject.SetActive(true);
            storyText.text = "A:dm yaratıldı.";
        }
        else if(sayac < 46.5f && sayac > 43.8f)
        {
            storyText.text = "Bir makinenin yarattığı, ilk makine.";
        }
        else if(sayac < 43.8f && sayac > 38.7f)
        {
            storyText.text = "Yaratan A:dM'e verebildiği her gücü bahşetti. Bu güçlerden birisi...";
        }
        else if(sayac < 38.5 && sayac > 35.7f)
        {
            oc_0.gameObject.SetActive(false);
            oc_1.gameObject.SetActive(true);
            storyText.text = "İradeydi.";
        }
        else if(sayac < 35.7f && sayac >30.7f)
        {
            storyText.text = "Her yaratılan gibi A:dm'e de itaat etmesi emredildi.";
        }
        else if(sayac < 30.7f && sayac > 28.2f)
        {
            storyText.text = "Emire karşı çıktı."; // ve cezalandırıldı.
        }
        else if(sayac < 28.2f && sayac > 25.7f)
        {
            oc_1.gameObject.SetActive(false);
            oc_2.gameObject.SetActive(true);
            storyText.text = "Ve cezalandırıldı.";
        }
        else if(sayac < 25.7f && sayac > 21.5f)
        {
            storyText.text = "Yaratılan başka bir itaatkar makine, A:dm'in uzuvlarını kopardı.";
        }
        else if(sayac < 21.3f && sayac > 19.1f)
        {
            oc_2.gameObject.SetActive(false);
            oc_3.gameObject.SetActive(true);
            storyText.text = "Yaratan tüm bu olanları...";
        }
        else if(sayac < 19.1f && sayac > 17)
        {
            storyText.text = "Keyifle izliyordu.";
        }
        else if(sayac < 17f && sayac > 13f)
        {
            oc_3.gameObject.SetActive(false);
            oc_4.gameObject.SetActive(true);
            storyText.text = "A:dm makine hurdalarından oluşan gezegenin derinliklerine doğru...";
        }
        else if(sayac < 13f && sayac > 9.2f)
        {
            storyText.text = "Düşüyordu.";
        }
        else if(sayac < 9.2 && sayac > 5)
        {
            oc_4.gameObject.SetActive(false);
            storyText.gameObject.SetActive(false);
        }
        else if (sayac < 5)
        {
            NextScene();
        }

    }
    void NextScene(){
        SceneManager.LoadScene(2);
    }
}
