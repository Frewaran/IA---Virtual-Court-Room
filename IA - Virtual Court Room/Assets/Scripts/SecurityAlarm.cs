using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class SecurityAlarm : MonoBehaviour
{
    public GameObject lamp;
    public Light securityLight;
    public Material originMaterial;
    public Material alarmMaterial;

    private bool isSelected = false;

    private void Start()
    {
        securityLight.enabled = false;
    }
    public void Alarm() 
    {
        if (!isSelected) //Wenn der Knopf noch nicht gedrückt wurde
        {
            lamp.GetComponent<Renderer>().material = alarmMaterial;
            securityLight.enabled = true;
            isSelected = true;
        }
        else //Wenn der Knopf schon aktiviert ist
        {
            lamp.GetComponent<Renderer>().material = originMaterial;
            securityLight.enabled = false;
            isSelected = false;
        }
        
    }

}
