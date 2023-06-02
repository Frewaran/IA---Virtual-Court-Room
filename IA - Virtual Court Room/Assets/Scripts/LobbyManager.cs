using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemList = new List<RoomItem>();
    public Transform contentObject;

    private void Start() {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate() { 
        if (roomInputField.text.Length >= 1) {
            PhotonNetwork.CreateRoom(roomInputField.text);
        }
    }

    public override void OnJoinedRoom() {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        UpdateRoomList(roomList);
    }

    void UpdateRoomList(List<RoomInfo> list) {
        foreach (RoomItem item in roomItemList) {
            Destroy(item.gameObject);
        }
        roomItemList.Clear();

        foreach (RoomInfo room in list) {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName) {
        PhotonNetwork.JoinRoom(roomName);
    }
}
