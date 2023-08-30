using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using Unity.XR.CoreUtils;
using System;
using ReadyPlayerMe.AvatarLoader;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit;

public class NewNetworkPlayer : MonoBehaviour {

    private PhotonView photonView;
    
    private void Awake() {
        photonView = GetComponent<PhotonView>();
    }
    private void Update() {
        if(!photonView.IsMine) {
            GetComponent<XROrigin>().enabled = false;
            GetComponent<InputActionManager>().enabled = false;
            GetComponent<LocomotionSystem>().enabled = false;
            GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
            GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
            GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
            GetComponent<CharacterControllerDriver>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<TeleportationProvider>().enabled = false;
            GetComponent<ActivateTeleportationRay>().enabled = false;
            GetComponent<Minimap>().enabled = false;
        }
    }
}
