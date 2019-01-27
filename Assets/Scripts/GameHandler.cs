using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    Score playerScore; // keeps the player's score details
    public Text score; // reference to the UI Text that shows the players score
    public Canvas pawsMenu; // reference to the Paws Menu UI

    public Transform minutes, seconds; // references the transforms of the clock hands

    float minutesToDegrees = 360f / 5f; // instead of 60 minutes we will do 5 here to make the gameplay quick
    float secondsToDegrees = 360f / 60f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScore = new Score();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Keep the clock updating while the time hasn't achieved 5 minutes
    void UpdateClock()
    {
        minutes.localRotation = Quaternion.Euler(0f, 0f, Time.deltaTime * -minutesToDegrees);
        seconds.localRotation = Quaternion.Euler(0f, 0f, Time.deltaTime * -secondsToDegrees);
    }
}
