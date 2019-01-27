using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudHandler : MonoBehaviour
{

    public List<GameObject> clouds;
    // Update is called once per frame
    void Update()
    {
        CheckCloudPosition(clouds[0]);
        CheckCloudPosition(clouds[1]);
    }

    void CheckCloudPosition(GameObject cloud)
    {
        // If clouds have left the screen, "respawn" at the start
        if(cloud.transform.position.x > 1600)
        {
            cloud.transform.position = new Vector3(-600, cloud.transform.position.y, cloud.transform.position.z);
        }
    }
}
