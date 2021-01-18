using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public int currentHealth;
    public static int score;

    public HealthBar healthBar;
    public GameObject gameOverScreen;
    public GameObject levelCompletePanel;
    public TextMeshProUGUI levelCompleteText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
   
    private GameObject[] pickups;
    private GameObject endPoint;
    private GameObject[] medPacks;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("currentHealth");
        // Uses the slider component and sets the max value
        // to 100
        healthBar.setMaxHealth(currentHealth);
        Debug.Log(currentHealth);

        // Will create an array list of all the pickups and medpacks in the level
        pickups = GameObject.FindGameObjectsWithTag("PickUp");
        medPacks = GameObject.FindGameObjectsWithTag("medPack");
        
        // Finds the endpoint and sets it inactive while all pickups are active in level
        endPoint = GameObject.FindGameObjectWithTag("End");
        endPoint.SetActive(false);

        score = PlayerPrefs.GetInt("playerScore");
        scoreText.SetText("Score: {0}", score);
    }

    // Update is called once per frame
    void Update()
    {
		// This function will be run if the player reaches
		// 0 health
        gameOver();

        bool allDisabled = true;

        // Goes through the array of all the pickups to check if they
        // are active. If some of them are still active the loop will
        // continue to run. The loop will only end once all of the pickups
        // are inactive
        for (int i = 0; i < pickups.Length; i++)
        {
            if (pickups[i].activeSelf)
            {
                allDisabled = false;
                break;
            }
            else
            {
                allDisabled = true;
            }
        }

        // Once allDisabled is true the endPoint will become active
        if (allDisabled == true)
        {
            endPoint.SetActive(true);
        }
    }

    void TakeDamage(int damage)
    {
        Debug.Log(damage);

		// Takes currentHealth = 100 and takes away set damage
		// for the hazard the player has collided with
        currentHealth -= damage;
        Debug.Log(currentHealth);

		// Then sets the health to the current value
        healthBar.setHealth(currentHealth);
    }

    void gameOver()
    {
		// Checks to see if the players health is equal to 0
        if(currentHealth == 0)
        {
            // Sets the cursor visble and unlocked
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // If the players health is equal to 0
            // the game over screen will become active
            // and the player will be destroyed
            Debug.Log("Game Over");

            // Sets Game Over Screen Active
            gameOverScreen.SetActive(true);

            gameOverText.SetText("Final Score: {0}", score);

            // Sets the player inactive in the scene
            // This is so the player cannot continue playing after the
            // health bar has reached 0
            GameObject.Find("Player").SetActive(false);
            GameObject.Find("Health bar").SetActive(false);
            GameObject.Find("Score").SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
		// Checks to see if the player has collided with any hazards
		// If the player does collide with a hazard it will be destroyed
		// and will take 20 points of health away
        if (other.gameObject.tag == "DontPickUp")
        {
            int damageTaken = 20;
            Debug.Log("Hit");
            other.gameObject.SetActive(false);
            TakeDamage(damageTaken);
        }

        // When the player collides with the end point the level
        // complete screen will appear and show the score
        if (other.gameObject == endPoint)
        {
            if (SceneManager.GetActiveScene().buildIndex != 6)
            {
                Time.timeScale = 0;
                // Sets the cursor visble and unlocked
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                levelCompleteText.SetText("Score: {0}", score);
                levelCompletePanel.SetActive(true);
            }

            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                Time.timeScale = 0;
                // Sets the cursor visble and unlocked
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                levelCompleteText.SetText("Final Score: {0}", score);
                levelCompletePanel.SetActive(true);
            }
        }

        // Checks to see if the players current health doesn't equal 100
        if (currentHealth != 100f)
        {
            // If the players current health is less than 100
            // it will then destroy the medPack and add 20 back
            // to your current health and health bar
            if (other.gameObject.tag == "medPack")
            {
                other.gameObject.SetActive(false);
                healthBar.addHealth(20);
                currentHealth += 20;
                Debug.Log(currentHealth);
            }
        }

        if (other.gameObject.tag == "PickUp")
        {
            // Will add 20 points to the score each time
            // The player picks up an object that won't
            // cause any damage
            score += 20;
            PlayerPrefs.SetInt("playerScore", score);
            Debug.Log("Score: " + score);
            scoreText.SetText("Score: {0}", score);
        }
    }
}
