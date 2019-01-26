using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public bool canHold = true; // can the player pick something up
    public GameObject grabbedItem; // object the player has grabbed
    public Transform guide; // position the object is held at
    public float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput() {
        // If the player tries to grab something
        if (Input.GetMouseButtonDown(0))
        {
            if (canHold)
            {
                PickUp();
            }
        }

        // if the player lets go of the mouse, drop the item
        if (Input.GetMouseButtonUp(0))
        {
            if (!canHold)
            {
                Drop();
            }
        }

        // make sure the grabbed item is always in front of you
        if (!canHold && grabbedItem)
        {
            grabbedItem.transform.position = guide.position;
        }
    }

    private void PickUp()
    {
        if (!grabbedItem)
            return;

        //We set the object parent to our guide empty object.
        grabbedItem.transform.SetParent(guide);

        //Set gravity to false while holding it
        grabbedItem.GetComponent<Rigidbody>().useGravity = false;

        //we apply the same rotation our main object (Camera) has.
        grabbedItem.transform.localRotation = transform.rotation;

        // Don't let the object rotate
        grabbedItem.GetComponent<Rigidbody>().freezeRotation = true;

        //We re-position the ball on our guide object 
        grabbedItem.transform.position = guide.position;

        canHold = false;
    }

    private void Drop()
    {
        if (!grabbedItem)
            return;

        //Set our Gravity to true again.
        grabbedItem.GetComponent<Rigidbody>().useGravity = true;

        // let the object do it's thing again
        grabbedItem.GetComponent<Rigidbody>().freezeRotation = false;

        // we don't have anything to do with our ball field anymore
        grabbedItem = null;
        //Apply velocity on throwing
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed; // TODO: change value of 2 to the value when whipping the camera around

        //Unparent our ball
        guide.GetChild(0).parent = null;
        canHold = true;
    }

    //We can use trigger or Collision
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "pillow")
            if (!grabbedItem) // if we don't have anything holding
                grabbedItem = col.gameObject;
    }

    //We can use trigger or Collision
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "pillow")
        {
            if (canHold)
                grabbedItem = null;
        }
    }
}
