using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject UI;
    [SerializeField] private Button button;
    [SerializeField] private InputField inputField;

    /* [Multiplayer]
     * Wenn die Szene startet, dann wird man erstmal ein Listener auf den Button hinzugefügt.
     * Dieser guckt, ob der Knopf gedrückt wird. Wenn ja, dann beginnt OnButtonClicked().
     */
    private void Awake() {
        button.onClick.AddListener(OnButtonClicked);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void OnButtonClicked() {
        /* [Multiplayer]
         * Hier wird versucht auf den Photon-Server sich zu verbinden.
         */
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Trying to connect to server...");
    }

    /* [Multiplayer]
     * Das ist eine spezielle Funktion von Photon. Wenn man zum Master verbunden ist, also wenn ConnectToServer() funktioniert hat, dann wird diese Funktion automatisch ausgeführt.
     * Dann werden hier ein paar Einstellungen getroffen und am Ende wird man mit einem Raum verbunden oder erstellt diesen zuerst, wenn es ihn noch nicht gibt.
     */
    public override void OnConnectedToMaster() {
        Debug.Log("Connected to Master.");

        /* [Multiplayer]
         * Das ist eine spezielle Funktion von Photon. Wenn man zum Master verbunden ist, also wenn OnButtonClicked() funktioniert hat, dann wird diese Funktion automatisch ausgeführt.
         * Dann wird hier geguckt, ob man etwas im RPM-Inputfield drin stehen hat.
         * Wenn, dann werden hier ein paar Einstellungen getroffen und am Ende wird man mit einem Raum verbunden oder erstellt diesen zuerst, wenn es ihn noch nicht gibt.
         */
        if (!string.IsNullOrEmpty(inputField.text)) {
            PhotonNetwork.NickName = inputField.text;
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 10;
            roomOptions.IsVisible = true;
            roomOptions.IsOpen = true;
            PhotonNetwork.JoinOrCreateRoom("Ready Player Me", roomOptions, TypedLobby.Default);
        }
        else {
            Debug.Log("Please enter avatar URL");
        }
    }

    /* [Multiplayer]
     * Das ist eine spezielle Funktion von Photon. Wenn man mit einem Raum verbunden ist, dann wird diese Funktion automatisch ausgeführt.
     * Das ist nur ein Test, damit man in der Console sehen kann, ob es funktioniert hat.
     */
    public override void OnJoinedRoom() {
        Debug.Log("Joined a room.");

        UI.SetActive(false);
        GameObject character = PhotonNetwork.Instantiate("Character_Test", Vector3.zero, Quaternion.identity);
        character.GetComponent<NetworkPlayer>().LoadAvatar(inputField.text);
    }

    /* [Multiplayer]
     * Das ist eine spezielle Funktion von Photon. Wenn man ein neuer Spieler den Raum betritt, dann wird diese Funktion automatisch ausgeführt.
     * Das ist nur ein Test, damit man in der Console sehen kann, ob es funktioniert hat.
     */
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.Log("A new player joined the room");
    }
}
