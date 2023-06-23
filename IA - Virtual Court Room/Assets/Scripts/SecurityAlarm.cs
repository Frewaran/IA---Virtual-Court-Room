using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System;

public class SecurityAlarm : MonoBehaviourPun
{
    public GameObject lamp;
    public Light securityLight;
    public Material originMaterial;
    public Material alarmMaterial;

    private bool isSelected = false;

    private const byte COLOR_CHANGE_EVENT = 0;

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

        PhotonNetwork.RaiseEvent(COLOR_CHANGE_EVENT, isSelected, RaiseEventOptions.Default, SendOptions.SendUnreliable);
    }

    private void OnEnable() {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    private void OnDisable() {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj) {
        if (obj.Code == COLOR_CHANGE_EVENT) {
            object data = (object)obj.CustomData;
            bool isSelected = (bool)data;

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
}
