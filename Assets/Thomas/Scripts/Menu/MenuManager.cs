using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] Animator animator;

    #region - Main Menu -

    public void StartAnim()
    {
        animator.SetTrigger("Fade");
    }    
    
    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion

    #region - Pause Menu -

    // Update is called once per frame
    void Update()
    {
        //If start button or escape pressed
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //Take away UI and set time back to normal
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        //Add UI and set time to stopped
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
