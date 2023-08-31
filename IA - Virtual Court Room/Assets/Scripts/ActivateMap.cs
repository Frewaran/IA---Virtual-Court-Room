using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMap : MonoBehaviour
{
    bool mapIsActive = false;

    public PrimaryButtonWatcher primaryWatcher;
    public SecondaryButtonWatcher secondaryWatcher;

    public GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        primaryWatcher.primaryButtonPress.AddListener(onPrimaryButtonEvent); //Event, wenn der A oder X Button gedrückt wird
        secondaryWatcher.secondaryButtonPress.AddListener(onSecondaryButtonEvent); //Event, wenn der B oder Y Button gedrückt wird
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        if (!mapIsActive) //Nur wenn die nicht Map aktiviert ist
        {
            if (!pressed) //Je nach Abfrage wird das Event beim runterdrücken oder beim loslassen von A/X ausgelöst
            {
                map.GetComponent<Canvas>().enabled = true;
                mapIsActive = true;
            }
            
        }

    }

    public void onSecondaryButtonEvent(bool pressed)
    {
        if (mapIsActive) //Nur wenn die Map aktiviert ist
        {
            if (!pressed) //Je nach Abfrage wird das Event beim runterdrücken oder beim loslassen von B/Y ausgelöst
            {
                map.GetComponent<Canvas>().enabled = false;
                mapIsActive = false;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
