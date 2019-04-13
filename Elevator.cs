using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    [Header("Locations:")]
    public Transform top;
    public Transform bottom;
    public GameObject Panel;

    [Header("Door")]


    [Header("Is there a passenger?")]
    public bool hasRider;
    public GameObject PlayerParent;

    [Header("Smooth")]
    public float smooth;

    //States
    enum EleStates{goUp, goDown, PauseState};
    EleStates states;
    private Vector3 newPos;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.U) && hasRider == true)
        {
            // the elevator go up part
            states = EleStates.goUp;
        }

        if (Input.GetKeyDown(KeyCode.G) && hasRider == true)
        {
            // the elevator go down :> part
            states = EleStates.goDown;
        }

        //idk what this is, I wrote it and forgot it
        if (gameObject.transform == bottom.transform)
        {
            
        }

        if (gameObject.transform == top.transform)
        {
            
        }

        //Calls the function
        FMS();

    }

    void FMS ()
    {

        if (states == EleStates.goDown)
        {
            Debug.Log("Elevator: Going Down");

            // This sets newPos as the bottom node 
            newPos = bottom.position;
            // this gets the elevator down
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        } 

        if (states == EleStates.goUp)
        {
            Debug.Log("Elevator: Going Up");
            // This sets newPos as the top node
            newPos = top.position;
            // this gets the elevator up
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        } 

        if (states == EleStates.PauseState)
        {
            //Butt nothing happens here
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Controller")
        {
            // Panel.SetActive(true);

            //This sets the player parent as the elevator
            other.transform.SetParent(gameObject.transform, true);
            other.transform.localScale = other.transform.localScale;
            hasRider = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Controller")
        {
            //Removes the elevator as 
            other.transform.parent = null;
            hasRider = false;
        }
    }

}
