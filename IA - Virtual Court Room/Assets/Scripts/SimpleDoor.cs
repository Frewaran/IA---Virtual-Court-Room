using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class SimpleDoor : MonoBehaviour
{
    private Transform door;

    /* [Multiplayer]
     * XRSimpleNetworkInteractable wird hier genutzt, damit man die Ownership des Objektes weitergeben kann und
     * damit jeder im Raum das Benutzen sehen kann (siehe XRSimpleNetworkInteractable.cs);
     */
    private XRSimpleNetworkInteractable interactable;
    private bool isDragging = false;

    private Quaternion doorRotCurr;
    private bool doorIsClosed = false;
    private bool canToggleDoor = true;
    private float doorOpenRot;

    public int openedDegrees = 270;
    public int closedDegrees = 180;

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

        if (isDragging && canToggleDoor) //Interaktion muss begonnen haben und wenn ein Vorgang (z.B. Tür schließen) abgeschlossen ist, muss man erneut Interagieren um diese wieder öffnen zu können (soll nicht durchgehend auf und zu gehen)
        {
            if (doorHingesLeft) //Links befestigte Türen
                openAndCloseLeft();
            else                //Rechts befestigte Türen
                openAndCloseRight();
        }

    }

    private void openAndCloseLeft()
    {
        doorRotCurr = door.rotation;

        if (!doorIsClosed) //Wenn die Tür offen ist (wie zu Beginn)
        {
            door.rotation = Quaternion.Euler(270, closedDegrees, 0);
            doorIsClosed = true;
        }
        else //Wenn die Tür zu ist 
        {
            door.rotation = Quaternion.Euler(270, openedDegrees, 0);
            doorIsClosed = false;
        }
                
        canToggleDoor = false;


    }

    private void openAndCloseRight()
    {
        doorRotCurr = door.rotation;

        if (!doorIsClosed) //Wenn die Tür offen ist (wie zu Beginn)
        {
            door.rotation = Quaternion.Euler(270, closedDegrees, 0);
            doorIsClosed = true;
        }
        else //Wenn die Tür zu ist 
        {
            door.rotation = Quaternion.Euler(270, openedDegrees-180, 0);
            doorIsClosed = false;
        }
        
        canToggleDoor = false;

    }




}
