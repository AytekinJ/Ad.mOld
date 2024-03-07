using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameManager : MonoBehaviour
{
    bool readyToCreate;
    public GameObject pplayer;
    public GameObject destroyedPlayer;
    public GameObject cloudObjectt;
    float sayac = 1;

    // Update is called once per frame
    void Update()
    {
        if(readyToCreate && sayac > 0)
        {
            sayac -= Time.deltaTime;
            Destroy(cloudObjectt, 2.5f);
        }
        else if(readyToCreate && sayac < 0)
        {
            pplayer.SetActive(true);
        }

        if(readyToCreate == false)
        {
            readyToCreate = destroyedPlayer.GetComponent<OneArmMoving>().readyToDestroy;
        }
        
    }
}
