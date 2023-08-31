using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject lobbyPanel;
    public GameObject roomPanel;

    public void OnClickConnect() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby() {
        Debug.Log("Joined to Lobby");
    }

    public void OnClickJoinOrCreate() {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Room", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("MultiplayerScene");
    }

    public void OnClickLeave() {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom() {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    //Zum Verlassen des Multiplayer-Bereiches im Hauptmenü.
    public void OnClickMainMenu() {
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.Disconnect();
    }

    //Wenn auf den Quit-Button gedrückt wird, wird die Anwendung geschlossen.
    public void QuitApplication() {
        Application.Quit();
    }
}
//Mert Kara
