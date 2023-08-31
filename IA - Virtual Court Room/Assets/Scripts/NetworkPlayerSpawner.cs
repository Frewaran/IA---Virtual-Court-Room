using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    /* [Multiplayer]
     * Wenn man die Szene l�dt, dann wird eines neuer Character erschaffen.
     */
    private void Start() {
        if(PhotonNetwork.InRoom) {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Character", transform.position, transform.rotation);
        }
    }

    /* [Multiplayer]
     * Wenn jemand den Raum verl�sst, dann wird dessen Character zerst�rt.
     */
    public override void OnLeftRoom() {
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }   
}
