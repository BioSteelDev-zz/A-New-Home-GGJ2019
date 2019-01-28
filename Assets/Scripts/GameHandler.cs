using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    Score playerScore; // keeps the player's score details
    public Text score; // reference to the UI Text that shows the players score
    public Canvas pawsMenu; // reference to the Paws Menu UI
    public Button Resume; // reference to resume button
    public Text gameOverScore; // reference to game over score
    public Canvas gameOverMenu; // reference to game over menu
    public Canvas HUD; // reference to hud menu
    public MouseLook playerHeadController; // reference to mouselook script on player
    public PlayerController playerController; // reference to playerController script on player

    public Transform minutes, seconds; // references the transforms of the clock hands

    const float minutesToDegrees = 360f / 5f; // instead of 60 minutes we will do 5 here to make the gameplay quick
    const float secondsToDegrees = 360f / 60f;

    float timer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // make mouse no longer visible
        Cursor.visible = false;

        playerScore = new Score();
        Resume.onClick.AddListener(ResumeGame);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the Clock
        UpdateClock();

        // if player pawses
        if(Input.GetKeyDown("escape")){
            PauseGame();
        }
    }

    // Keep the clock updating while the time hasn't achieved 5 minutes
    void UpdateClock()
    {
        // Run the timer
        timer += Time.deltaTime;

        float min = Mathf.Floor(timer / 60);
        float sec = (timer % 60);

        minutes.localRotation = Quaternion.Euler(0f, 0f, min * -minutesToDegrees);
        seconds.localRotation = Quaternion.Euler(0f, 0f, sec * -secondsToDegrees);

        // If timer exceeds 5 minutes, end the game
        if (timer > 300.0f)
        {
            GameOver();
        }
    }

    // Resume the game if leaving paws menu
    void ResumeGame()
    {
        Cursor.visible = false;
        HUD.gameObject.SetActive(true);
        pawsMenu.gameObject.SetActive(false);
        playerController.enabled = true;
        playerHeadController.enabled = true;
    }

    // if the game is pawsd, do this
    void PauseGame()
    {
        Cursor.visible = true;
        HUD.gameObject.SetActive(false);
        pawsMenu.gameObject.SetActive(true);
        playerController.enabled = false;
        playerHeadController.enabled = false;
    }

    // if the game ends, do this
    void GameOver()
    {
        Cursor.visible = true;
        HUD.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(true);
        playerController.enabled = false;
        playerHeadController.enabled = false;
    }

    // Update Playerscore with the appropriate points
    public void UpdatePlayerScore(int points)
    {
        playerScore.AddPoints(points);
        score.text = playerScore.GetPoints().ToString();
        gameOverScore.text = playerScore.GetPoints().ToString();
    }
}
