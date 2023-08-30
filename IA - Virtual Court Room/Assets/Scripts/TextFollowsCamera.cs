using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFollowsCamera : MonoBehaviour
{
    private bool isSelected = false;

    public SecondaryButtonWatcher watcher;
    public Material readMaterial;

    private int distanceToDeactivate; 

    // Start is called before the first frame update
    void Start()
    {
        distanceToDeactivate = 4;
        watcher.secondaryButtonPress.AddListener(onSecondaryButtonEvent); //Event, wenn der B oder Y Button gedrückt wird
    }

    public void onSecondaryButtonEvent(bool pressed)
    {
        if (isSelected) //Nur wenn man den Infopoint aktiviert hat
        {
            if (!pressed) //Je nach Abfrage wird das Event beim runterdrücken oder beim loslassen von B/Y ausgelöst
                textNotVisible();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            //Text richtet sich zur Kamera hin aus.
            transform.LookAt(Camera.main.transform); 
            transform.Rotate(0, 180, 0);

            //Wenn man sich vom Text entfernt, soll er sich deaktivieren
            Vector3 distanceVector = transform.position - Camera.main.transform.position;
            float distanceToText = distanceVector.magnitude;
            if (distanceToText > distanceToDeactivate)
                textNotVisible();
        }
    }

    public void textVisible()
    {
        
        Vector3 distanceVector = transform.position - Camera.main.transform.position;
        float distanceToText = distanceVector.magnitude;

        if (distanceToText <= distanceToDeactivate) //Wenn man zu weit vom Text entfernt ist, soll er nicht aktiviert werden
        {
            transform.GetComponent<Canvas>().enabled = true;
            transform.parent.GetComponent<MeshRenderer>().enabled = false; //Infopoint wird in der Zeit unsichtbar
            isSelected = true; 
        }

    }

    public void textNotVisible()
    {
        transform.GetComponent<Canvas>().enabled = false;
        transform.parent.GetComponent<MeshRenderer>().enabled = true; //Infopoint wird wieder sichtbar
        isSelected = false;
        transform.parent.GetComponent<Renderer>().material = readMaterial; //Infopoint wird als gelesen markiert    
    }
}
