using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    /* [Multiplayer]
     * Wenn jemand den Raum betritt, dann wird eines neuer Character erschaffen.
     */
    public override void OnJoinedRoom() {
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Character", transform.position, transform.rotation);
    }

    /* [Multiplayer]
     * Wenn jemand den Raum verlässt, dann wird dessen Character zerstört.
     */
    public override void OnLeftRoom() {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
