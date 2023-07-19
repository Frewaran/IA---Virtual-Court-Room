using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using Unity.XR.CoreUtils;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public Transform body;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;

    /* [Multplayer]
     * PhotonView, damit die Bewegungen übertragen werden können und damit man differenzieren kann, welcher Spieler
     * man selber ist.
     */
    private PhotonView photonView;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;
    private Transform bodyRig;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();

        // Hier werden die jeweiligen Transforms für alle Spieler gefunden
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");
        bodyRig = rig.transform.Find("Character Model/metarig");

        /* [Multplayer]
         * Für einen selber werden die Komponenten ausgeblendet. Man selbst steuert nämlich nicht das hier erschaffene Rig, sondern
         * das XRRig, was bereits in der Szene ist.
         */
        if (photonView.IsMine) {
            foreach (var item in GetComponentsInChildren<Renderer>()) {
                item.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* [Multplayer]
         * Für einen selber werden die Komponenten ausgeblendet. Man selbst steuert nämlich nicht das hier erschaffene Rig, sondern
         * das XR-Rig, was bereits in der Szene ist.
         */
        if (photonView.IsMine) {
            rightHand.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);
            body.gameObject.SetActive(false);

            // Hiermit werden die Positionen der einzelnen Körperteile mit den Positionen des XR-Rigs gleichgesetzt
            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
            MapPosition(body, bodyRig);

            // Hiermit sollten eigentlich die Handbewegungen für alle sichtbar sein.
            if (leftHandAnimator != null && leftHandAnimator.isActiveAndEnabled) {
                UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            }
            if (rightHandAnimator != null && rightHandAnimator.isActiveAndEnabled) {
                UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), rightHandAnimator);
            }
        }
    }

    // Hier wird die Position der einzelnen Körperteile mit den Positionen des XR-Rigs gleichgesetzt
    void MapPosition(Transform target, Transform rigTransform) {

        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }

    // Hier sollten die HandAnimationen für alle berechnet werden.
    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator) {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else {
            handAnimator.SetFloat("Trigger", 0f);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue)) {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else {
            handAnimator.SetFloat("Grip", 0f);
        }
    }
}
