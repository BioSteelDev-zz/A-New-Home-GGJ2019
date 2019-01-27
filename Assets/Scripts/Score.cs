using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    // Holds the Player's Points
    private int Points;

    // Constructor
    public Score()
    {
        // Set points to 0
        Points = 0;
    }

    // Add points to Player's Points
    public void AddPoints(int value)
    {
        Points += value;
    }

    // Get the player's current points
    public int GetPoints()
    {
        return Points;
    }
}
