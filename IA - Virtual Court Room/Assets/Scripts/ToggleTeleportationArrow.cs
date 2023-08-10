using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;   

public class ToggleTeleportationArrow : MonoBehaviour
{
    public GameObject arrowMesh;
    public GameObject movementObjekt; //Darin sind die Skripts zum Bewegen, drehen etc.
    private string movementScript; //Der Name des Skripts das deaktiviert werden soll (z.B. movement zum Laufen)

    public SecondaryButtonWatcher watcher; 

    private MonoBehaviour deactivateMovement;
    private bool stuckInArrow = false; //gibt an ob man auf einer festen Position ist oder nicht

    //Events f�r das deaktivieren/aktivieren des Teleportationsstrahls
    public delegate void inArrow();
    public static event inArrow OnDeactivateRay;

    public delegate void outArrow();
    public static event outArrow OnActivateRay;


    // Start is called before the first frame update
    void Start()
    {
        watcher.secondaryButtonPress.AddListener(onSecondaryButtonEvent); //Event, wenn der B oder Y Button gedr�ckt wird

        movementScript = "ActionBasedContinuousMoveProvider";
        deactivateMovement = movementObjekt.GetComponent(movementScript) as MonoBehaviour;

    }


    public void onSecondaryButtonEvent(bool pressed)
    {
        if (stuckInArrow) //wird nur aufgerufen, wenn man auf fester Position ist.
        {
            if (!pressed) //Je nach Abfrage wird das Event beim runterdr�cken oder beim loslassen von B/Y ausgel�st
            {
                arrowMesh.SetActive(true); //Teleportationspfeil wird wieder sichtbar
                deactivateMovement.enabled = true; //Laufen wird wieder aktiviert (m�sste angepasst werden, wenn User das in den Einstellungen deaktivieren kann)
                if (OnActivateRay != null) //Teleportationsstrahl wird wieder aktiviert
                    OnActivateRay();

                stuckInArrow = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deactivateArrow()
    {

        arrowMesh.SetActive(false); //Teleportationspfeil unsichtbar machen
        deactivateMovement.enabled = false; //Laufen deaktivieren
        if (OnDeactivateRay != null) //Teleportationsstrahl deaktivieren
            OnDeactivateRay();
        stuckInArrow = true;
    }
}