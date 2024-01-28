using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeMenu : MonoBehaviour
{
    public void StartGameLevel1()
    {
        SceneManager.LoadScene(1);
    }
    
    public void StartGameLevel2()
    {
        SceneManager.LoadScene(2);
    }
}
