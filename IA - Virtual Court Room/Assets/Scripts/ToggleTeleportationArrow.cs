using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;   

public class ToggleTeleportationArrow : MonoBehaviour
{
    public GameObject arrowMesh;
    public GameObject movementObjekt; //Darin sind die Skripts zum Bewegen, drehen etc.
    public string movementScript;

    public SecondaryButtonWatcher watcher; 

    private bool IsPressed = false;
    private MonoBehaviour deactivateMovement;
    private bool stuckInArrow = false; //gibt an ob man auf einer festen Position ist oder nicht

    // Start is called before the first frame update
    void Start()
    {
        watcher.secondaryButtonPress.AddListener(onSecondaryButtonEvent);

        deactivateMovement = movementObjekt.GetComponent(movementScript) as MonoBehaviour;
    }


    public void onSecondaryButtonEvent(bool pressed)
    {
        if (stuckInArrow) //wird nur aufgerufen, wenn man auf fester Position ist.
        {
            IsPressed = pressed;
            if (!pressed)
            {
                arrowMesh.SetActive(true);
                deactivateMovement.enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void deactivateArrow()
    {
        arrowMesh.SetActive(false);
        deactivateMovement.enabled = false;
        stuckInArrow = true;
    }
}
