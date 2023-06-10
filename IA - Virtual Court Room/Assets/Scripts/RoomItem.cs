using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public void Start() {
        manager = FindObjectOfType<LobbyManager>();
    }
    public Text roomName;
    LobbyManager manager;

    public void SetRoomName(string _roomName) {
        roomName.text = _roomName;
    }

    public void OnClickItem() {
        manager.JoinRoom(roomName.text);
    }
}
