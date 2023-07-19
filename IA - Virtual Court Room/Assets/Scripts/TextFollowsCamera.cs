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

    // Start is called before the first frame update
    void Start()
    {
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
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);

            Vector3 distanceVector = transform.position - Camera.main.transform.position;
            float distanceToText = distanceVector.magnitude;
            if (distanceToText > 4)
                textNotVisible();
        }
    }

    public void textVisible()
    {
        transform.GetComponent<TextMeshPro>().enabled = true;
        transform.parent.GetComponent<MeshRenderer>().enabled = false;
        isSelected = true;
    }

    public void textNotVisible()
    {
        transform.GetComponent<TextMeshPro>().enabled = false;
        transform.parent.GetComponent<MeshRenderer>().enabled = true;
        isSelected = false;
        transform.parent.GetComponent<Renderer>().material = readMaterial;
    }
}
