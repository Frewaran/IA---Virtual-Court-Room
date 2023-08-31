using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    /* [Multiplayer]
     * Wenn man die Szene lädt, dann wird eines neuer Character erschaffen.
     */
    private void Start() {
        if(PhotonNetwork.InRoom) {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Character", transform.position, transform.rotation);
        }
    }

    /* [Multiplayer]
     * Wenn jemand den Raum verlässt, dann wird dessen Character zerstört.
     */
    public override void OnLeftRoom() {
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }   
}
