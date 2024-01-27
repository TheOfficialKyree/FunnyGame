using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    bool paused;

    #region - Main Menu -

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }    
    
    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion

    #region - Pause Menu -

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                paused = true;
                Time.timeScale = 1.0f;
            }
        }

        if (paused == true)
        {
            // Pause menu
        }
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
