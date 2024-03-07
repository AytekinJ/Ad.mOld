using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endCutScene : MonoBehaviour
{
    public Image fc_0, fc_1;
    public Text storyText;

    public float sayac = 50;  
    public GameObject oitAnim;
    public GameObject siyahRenk;
    
    void Update()
    {
        sayac -= Time.deltaTime;
    }

    private void FixedUpdate() {
        if(sayac < 48.5f && sayac > 43.5f)
        {   
            fc_0.gameObject.SetActive(true);
            storyText.gameObject.SetActive(true);
            storyText.text = "A:dm'in kendisini yaratan gizemli makineyle ikinci karşılaşmasıydı.";
        }
        else if(sayac < 43.5f && sayac > 40.5f)
        {
            storyText.text = "A:dM'i yenebilecek güçte fedaisi kalmamıştı.";
        }
        else if(sayac < 40.5f && sayac > 38.2f)
        {
            storyText.text = "Ancak yaratma gücü olduğu gibi yok etme gücüne de sahipti."; //Hesaba katmadığı şey ise... || Her makinenin... || Bir güç kaynağı vardır.
        }
        else if(sayac < 38.2 && sayac > 35.7f)
        {
            fc_0.gameObject.SetActive(false);
            
            storyText.text = "Hesaba katmadığı şey ise...";
        }
        else if(sayac < 35.7f && sayac > 33)
        {
            storyText.text = "Her makinenin...";
        }
        else if(sayac < 33 && sayac > 30.1f)
        {
            fc_1.gameObject.SetActive(true);

            storyText.text = "Bir güç kaynağı vardır";
        }
        else if(sayac < 30.1f && sayac > 27.7f)
        {
            fc_1.gameObject.SetActive(false);
            storyText.text = "";
        }
        else if(sayac < 27.7f && sayac > 3)
        {
            siyahRenk.gameObject.SetActive(false);
            oitAnim.SetActive(true);
        }
        else if(sayac < 3)
        {
            SceneManager.LoadScene(6);
        }
    }
}
