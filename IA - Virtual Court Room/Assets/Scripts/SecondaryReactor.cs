using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryReactor : MonoBehaviour
{
    public SecondaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity __Inspector__ window

    // Start is called before the first frame update
    void Start()
    {
        watcher.secondaryButtonPress.AddListener(onSecondaryButtonEvent);
    }

    public void onSecondaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (pressed)
            Debug.Log("B/Y gedrückt");
        else
            Debug.Log("B/Y losgelassen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
