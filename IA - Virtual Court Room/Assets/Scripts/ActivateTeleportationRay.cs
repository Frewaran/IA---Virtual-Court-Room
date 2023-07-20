using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    private bool stuckInArrow = false;

    private void OnEnable()
    {
        ToggleTeleportationArrow.OnDeactivateRay += DeactivateRayInArrow; //Teleportationsstrahl deaktivieren
        ToggleTeleportationArrow.OnActivateRay += ActivateRayInArrow; //Teleportationsstrahl aktivieren
    }

    private void OnDisable()
    {
        ToggleTeleportationArrow.OnDeactivateRay -= DeactivateRayInArrow;
        ToggleTeleportationArrow.OnActivateRay -= ActivateRayInArrow;
    }

    void Update()
    {
        leftTeleportation.SetActive(leftActivate.action.ReadValue<UnityEngine.Vector2>().y > 0.1f);
        rightTeleportation.SetActive(rightActivate.action.ReadValue<UnityEngine.Vector2>().y > 0.1f);

        if (stuckInArrow) //Für den Fall dass man in einem Teleportationsplatz ist, soll man den Strahl nicht mehr aktivieren können
        {
            leftTeleportation.SetActive(false);
            rightTeleportation.SetActive(false);
        }
    }

    void DeactivateRayInArrow()
    {
        stuckInArrow = true;
    }

    void ActivateRayInArrow()
    {
        stuckInArrow = false;
    }
}
