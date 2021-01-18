using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle fullscreen;
    public int playerHealth;
    public AudioSource musicSource;
    public Slider volume;

    private float musicVolume = 1f;

    public void PlayGame()
    {
        PlayerPrefs.SetInt("playerScore", 0);
        PlayerPrefs.SetInt("currentHealth", playerHealth);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Sets the cursor invisble and locked
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        // While working in Unity the game will not close
        // This debug message is used to indicate that the function will work
        Debug.Log("QUIT!");
        Application.Quit();
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

    public void loadLevel(int levelNumber)
    {
        PlayerPrefs.SetInt("playerScore", 0);
        PlayerPrefs.SetInt("currentHealth", playerHealth);
        SceneManager.LoadScene(levelNumber);
        // Sets the cursor invisble and locked
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PlayMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Pause();
        else
            musicSource.Play();
    }

    public void setVolume(float vol)
    {
        musicVolume = vol;
    }

    private void Update()
    {
        musicSource.volume = musicVolume;
    }
}
