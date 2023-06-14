using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class SecurityAlarm : MonoBehaviour
{
    public GameObject lamp;
    public Material originMaterial;
    public Material alarmMaterial;

    private bool isSelected = false;

    public void Alarm() 
    {
        if (!isSelected) //Wenn der Knopf noch nicht gedrückt wurde
        {
            lamp.GetComponent<Renderer>().material = alarmMaterial;
            isSelected = true;
        }
        else //Wenn der Knopf schon aktiviert ist
        {
            lamp.GetComponent<Renderer>().material = originMaterial;
            isSelected = false;
        }
        
    }

}
