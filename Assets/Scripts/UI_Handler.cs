using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Handler : MonoBehaviour
{
    public GameObject pausePanel;
    public Toggle fullscreen;

    private GameObject healthBar;
    private GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        // sets panel to not be visible to the player
        pausePanel.SetActive(false);
        healthBar = GameObject.Find("Health bar");
        score = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        // Sets the cursor visble and unlocked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        // sets panel to be visible to the player
        pausePanel.SetActive(true);
        // sets health bar to be invisible while in pause menu
        healthBar.SetActive(false);
        score.SetActive(false);
    }
    public void continueGame()
    {
        // Sets the cursor invisble and locked
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        // sets panel to be visible to the player
        pausePanel.SetActive(false);
        // sets health bar to be visible when player goes back to playing game
        healthBar.SetActive(true);
        score.SetActive(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        // sets the time scale back to one so the game can be played
        // if timescale remained on 0 the game would freeze
        Time.timeScale = 1;
    }

    public void retryLevel()
    {
        PlayerPrefs.SetInt("playerScore", 0);
        PlayerPrefs.SetInt("currentHealth", 100);
        // Sets the cursor invisble and locked
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Gets current scene and reloads it
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }

    public void nextLevel()
    {
        PlayerPrefs.GetInt("playerScore");
        PlayerPrefs.GetInt("currentHealth");

        // Sets the cursor invisble and locked
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Gets the current scene and adds 1
        // This will load the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void setFullScreen(bool isFullscreen)
    {
        // Checks to see if Fullscreen is not on
        // If it isn't on the boolean will be set to false
        if (!fullscreen.isOn)
        {
            isFullscreen = false;
        }

        // It then sets the screen to be fullscreen
        // or not fullscreen depending on what state
        // the boolean is in (true/false)
        Screen.fullScreen = isFullscreen;
        if (isFullscreen == true)
            Debug.Log("Fullscreen");
        else
            Debug.Log("Not Fullscreen");
    }
}
