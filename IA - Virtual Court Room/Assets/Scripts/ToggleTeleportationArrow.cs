using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;   

public class ToggleTeleportationArrow : MonoBehaviour
{
    public GameObject arrowMesh;

    public SecondaryButtonWatcher watcher; 

    private bool IsPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        watcher.secondaryButtonPress.AddListener(onSecondaryButtonEvent);
    }


    public void onSecondaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (!pressed)
        {
            arrowMesh.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void deactivateArrow()
    {
        arrowMesh.SetActive(false);
    }
}
