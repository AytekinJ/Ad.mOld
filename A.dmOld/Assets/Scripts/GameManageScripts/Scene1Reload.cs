using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1Reload : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(4);
    }
}
