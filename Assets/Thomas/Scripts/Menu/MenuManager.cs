using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI, mainMenuUI, levelSelectUI, controlsUI;
    [SerializeField] Animator animator;
    [SerializeField] SoundManager soundManager;

    #region - Main Menu -

    public void OpenLevelSelect()
    {
        levelSelectUI.SetActive(true);
        mainMenuUI.SetActive(false);
        soundManager.PlayMenuMove();
    }

    public void CloseLevelSelect()
    {
        levelSelectUI.SetActive(false);
        mainMenuUI.SetActive(true);
        soundManager.PlayMenuMove();
    }

    public void OpenControls()
    {
        controlsUI.SetActive(true);
        mainMenuUI.SetActive(false);
        soundManager.PlayMenuMove();
    }

    public void CloseControls()
    {
        controlsUI.SetActive(false);
        mainMenuUI.SetActive(true);
        soundManager.PlayMenuMove();
    }

    public void StartAnim1()
    {
        animator.SetTrigger("Fade1");
        soundManager.PlayMenuMove();
    }

    public void StartAnim2()
    {
        animator.SetTrigger("Fade2");
        soundManager.PlayMenuMove();
    }

    public void QuitGame()
    {
        soundManager.PlayMenuMove();
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
        Resume();
        SceneManager.LoadScene(0);
    }

    public void RestartLevel1()
    {
        Resume();
        SceneManager.LoadScene(1);
    }

    public void RestartLevel2()
    {
        Resume();
        SceneManager.LoadScene(2);
    }

    #endregion
}
