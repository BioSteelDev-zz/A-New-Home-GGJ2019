using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour
{
    public float speed; // speed at which the cloud translate across the screen
    
    void Update()
    {
        // Move the cloud across the screen
        transform.Translate(Time.deltaTime * speed, 0, 0);
    }
}
