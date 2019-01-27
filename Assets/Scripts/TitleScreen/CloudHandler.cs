using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudHandler : MonoBehaviour
{
    public GameObject cloud; // holds a cloud prefab
    public List<Texture2D> cloudSprites; // holds textures to set for clouds
    
    // Update is called once per frame
    void Update()
    {
        CheckCloudPosition("front");
        CheckCloudPosition("back");
    }

    // Spawn a cloud
    void SpawnCloud(string tag)
    {
        // Use Texture2D list[0] for back cloud texture, list[1] for front
        // Set front speed faster than back speed
        // Set appropriate tag
    }

    void CheckCloudPosition(string tag)
    {
        // Check cloud based on tag
        // If cloud is outside of canvas, delete old cloud
        // If cloud is outside of canvas, spawn a new cloud
    }
}
