using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using Unity.XR.CoreUtils;
using System;
using ReadyPlayerMe.AvatarLoader;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Animations.Rigging;

public class NewNetworkPlayer : MonoBehaviour {

    private PhotonView photonView;
    
    private void Awake() {
        photonView = GetComponent<PhotonView>();
    }
    private void Start() {
        if(!photonView.IsMine) {
            GetComponent<XROrigin>().enabled = false;
            GetComponent<InputActionManager>().enabled = false;
            GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
            GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
            GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
            GetComponent<LocomotionSystem>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<CharacterControllerDriver>().enabled = false;
            GetComponent<TeleportationProvider>().enabled = false;
            GetComponent<ActivateTeleportationRay>().enabled = false;

            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);

            transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.layer = 0;
            transform.GetChild(6).gameObject.transform.GetChild(1).gameObject.layer = 0;
            transform.GetChild(6).gameObject.transform.GetChild(2).gameObject.layer = 0;
            transform.GetChild(6).gameObject.transform.GetChild(3).gameObject.layer = 0;

            transform.GetChild(6).gameObject.transform.GetChild(9).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.transform.GetChild(10).gameObject.SetActive(false);

            GetComponentInChildren<AvatarData>().enabled = false;
            GetComponentInChildren<EyeAnimationHandler>().enabled = false;
            GetComponentInChildren<AvatarController>().enabled = false;
            GetComponentInChildren<RigBuilder>().enabled = false;
            GetComponentInChildren<BoneRenderer>().enabled = false;
            GetComponentInChildren<AnimateHandOnInput>().enabled = false;
            GetComponentInChildren<LowerBodyAnimator>().enabled = false;
            GetComponentInChildren<AnimationController>().enabled = false;
            GetComponentInChildren<AnimationController>().enabled = false;
        }
    }
}
