using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using Photon.Pun;
using System;

/* [MULTIPLAYER]
 * MonoBehaviour wurde zu MonoBehaviourPun erweitert, weil man so das photonView-Element nutzen kann
 */
public class SecurityAlarm : MonoBehaviourPun
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
        /* [MULTIPLAYER]
         * Man nutzt nicht mehr einfach SetAlarm(); zum Ausführen des Befehls, sondern nutzt von der photonView-Komponente .RPC und wählt .All als Target, damit es für alle gilt.
         */
        photonView.RPC("SetAlarm", RpcTarget.All, isSelected);
        //SetAlarm();
    }

    /* [MULTIPLAYER]
     * Wenn eine Funktion für alle ausgeführt werden soll, dann wir davor [PunRPC] geschrieben.
     */
    [PunRPC]
    public void SetAlarm(bool _isSelected) {
        if (!_isSelected) //Wenn der Knopf noch nicht gedrückt wurde
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
