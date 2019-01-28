using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    public int Health = 5;
    Vector3 lastPosition;
    public bool grabbed = false;

    float timer = 0.0f;
    bool waitForHit = false;

    private void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForHit)
        {
            timer += Time.deltaTime;
        }

        if(timer > 1)
        {
            waitForHit = false;
        }

        if(Health == 0)
        {
            GameObject.Find("GameManager").GetComponent<GameHandler>().UpdatePlayerScore(100);
            if(GameObject.Find("Main Camera").GetComponent<GrabObject>().grabbedItem != null)
            {
                GameObject.Find("Main Camera").GetComponent<GrabObject>().grabbedItem = null;
                GameObject.Find("Main Camera").GetComponent<GrabObject>().canHold = true;
                GameObject.Find("Main Camera").GetComponent<GrabObject>().guide.GetChild(0).parent = null;
            }
            Destroy(gameObject);
        }

        CheckPosition();
    }

    void CheckPosition()
    {
        if (transform.position.x > lastPosition.x || transform.position.x < lastPosition.x)
        {
            TakeDamage();
            lastPosition = transform.position;
        }
    }

    // Damage the pillow
    public void TakeDamage()
    {
        if (grabbed && !waitForHit)
        {
            Health -= 1;
            ShootParticles();
            timer = 0.0f;
            waitForHit = true;
        }
    }

    void ShootParticles()
    {
        GetComponent<ParticleSystem>().Play();
    }
}
