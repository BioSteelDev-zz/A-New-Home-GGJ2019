using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public List<Texture2D> buttonTextures;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        // Change Texture to hover button
        
        // Play a sound
    }

    public void OnMouseExit()
    {
        //Change Texture to static button
    }

    public void PlayGame()
    {

    }
}
