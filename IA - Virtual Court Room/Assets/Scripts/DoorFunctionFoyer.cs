using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class DoorFunction : MonoBehaviour
{
    private Transform door;

    private XRSimpleNetworkInteractable interactable;
    private bool isDragging = false;

    private Quaternion doorRotCurr;
    private bool doorIsClosed = false;
    private bool canToggleDoor = true;
    private float doorOpenRot;

    public float doorSpeed = 50f;

    public bool doorHingesLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        door = transform;
        doorOpenRot = door.rotation.eulerAngles.y;

        interactable = GetComponent<XRSimpleNetworkInteractable>();
        interactable.selectEntered.AddListener(StartDrag);
        interactable.selectExited.AddListener(StopDrag);
    }

    public void StartDrag(BaseInteractionEventArgs select)
    {
        isDragging = true;
        canToggleDoor = true;
    }

    private void StopDrag(BaseInteractionEventArgs select)
    {
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isDragging && canToggleDoor) //Interaktion muss begonnen haben und wenn ein Vorgang (z.B. T�r schlie�en) abgeschlossen ist, muss man erneut Interagieren um diese wieder �ffnen zu k�nnen (soll nicht durchgehend auf und zu gehen)
        {
            if (doorHingesLeft) //Links befestigte T�ren
                openAndCloseLeft();
            else                //Rechts befestigte T�ren
                openAndCloseRight();
        }

    }

    private void openAndCloseLeft()
    {
        doorRotCurr = door.rotation;

        if (!doorIsClosed) //Wenn die T�r offen ist (wie zu Beginn)
        {
            if (doorRotCurr.eulerAngles.y > 0.1f && doorRotCurr.eulerAngles.y <= 90f) //T�r wird geschlossen 
            {
                door.Rotate(0f, 0f, -doorSpeed * Time.deltaTime);
            }
            else if (doorRotCurr.eulerAngles.y > 90f || door.rotation == Quaternion.Euler(270, 0, 0)) //T�r wird genau zu 0 Grad, auch wenn sie etwas zu weit rotiert ist
            {
                door.rotation = Quaternion.Euler(270, 0, 0);
                doorIsClosed = true;
                canToggleDoor = false;
            }
        }
        else //Wenn die T�r zu ist 
        {
            if (doorRotCurr.eulerAngles.y >= 0f && doorRotCurr.eulerAngles.y < 89.9f) //T�r wird ge�ffnet
            {
                door.Rotate(0f, 0f, doorSpeed * Time.deltaTime);
            }
            else if (doorRotCurr.eulerAngles.y > 90f || door.rotation == Quaternion.Euler(270, 90, 0)) //T�r wird genau zu 90 Grad, auch wenn sie etwas zu weit rotiert ist
            {
                door.rotation = Quaternion.Euler(270, 90, 0);
                doorIsClosed = false;
                canToggleDoor = false;
            }
        }

        
    }

    private void openAndCloseRight()
    {
        doorRotCurr = door.rotation;

        if (!doorIsClosed) //Wenn die T�r offen ist (wie zu Beginn)
        {
            if (doorRotCurr.eulerAngles.y < 359.9f && doorRotCurr.eulerAngles.y >= 270f) //T�r wird geschlossen 
            {
                door.Rotate(0f, 0f, doorSpeed * Time.deltaTime);
            }
            else if (doorRotCurr.eulerAngles.y < 270f || door.rotation == Quaternion.Euler(270, 0, 0)) //T�r wird genau zu 0 Grad, auch wenn sie etwas zu weit rotiert ist
            {
                door.rotation = Quaternion.Euler(270, 0, 0);
                doorIsClosed = true;
                canToggleDoor = false;
            }
        }
        else //Wenn die T�r zu ist 
        {
            if (doorRotCurr.eulerAngles.y == 0f || doorRotCurr.eulerAngles.y <= 360f && doorRotCurr.eulerAngles.y > 270.1f) //T�r wird ge�ffnet
            {
                door.Rotate(0f, 0f, -doorSpeed * Time.deltaTime);
            }
            else if (doorRotCurr.eulerAngles.y > 0f && doorRotCurr.eulerAngles.y < 270f || door.rotation == Quaternion.Euler(270, -90, 0))
            {
                door.rotation = Quaternion.Euler(270, -90, 0);
                doorIsClosed = false;
                canToggleDoor = false;
            }
        }


    }

    //doorAngle = doorAngle > 180f ? doorAngle - 360f : doorAngle; // Normalisiere den Winkel auf den Bereich von -180 bis 180 Grad


}
