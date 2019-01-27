using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("soundbox"));
    }
    void Start()
    {
        // if on title screen, show cursor
        Cursor.visible = true;
    }
}
