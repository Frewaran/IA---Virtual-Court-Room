using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public Text buttonText;
    public GameObject connectUI;
    public GameObject roomUI;

    public void OnClickConnect() {
        buttonText.text = "Raum wird betreten...";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        connectUI.SetActive(false);
        roomUI.SetActive(true);
    }
}
