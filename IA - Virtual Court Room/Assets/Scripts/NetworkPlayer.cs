using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using Unity.XR.CoreUtils;
using System;
using ReadyPlayerMe.AvatarLoader;

public class NetworkPlayer : MonoBehaviour {
    public Transform armature;
    public Transform hips;
    public Transform spine;
    public Transform spine1;
    public Transform spine2;
    public Transform neck;
    public Transform head;
    public Transform headtop;
    public Transform lefteye;
    public Transform righteye;
    public Transform leftshoulder;
    public Transform leftarm;
    public Transform leftforarm;
    public Transform lefthand;
    public Transform rightshoulder;
    public Transform rightarm;
    public Transform rightforarm;
    public Transform righthand;
    public Transform leftupleg;
    public Transform leftleg;
    public Transform leftfoot;
    public Transform rightupleg;
    public Transform rightleg;
    public Transform rightfoot;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;

    /* [Multplayer]
     * PhotonView, damit die Bewegungen übertragen werden können und damit man differenzieren kann, welcher Spieler
     * man selber ist.
     */
    private PhotonView photonView;

    private Transform armatureRig;
    private Transform hipsRig;
    private Transform spineRig;
    private Transform spine1Rig;
    private Transform spine2Rig;
    private Transform neckRig;
    private Transform headRig;
    private Transform headtopRig;
    private Transform lefteyeRig;
    private Transform righteyeRig;
    private Transform leftshoulderRig;
    private Transform leftarmRig;
    private Transform leftforarmRig;
    private Transform lefthandRig;
    private Transform rightshoulderRig;
    private Transform rightarmRig;
    private Transform rightforarmRig;
    private Transform righthandRig;
    private Transform leftuplegRig;
    private Transform leftlegRig;
    private Transform leftfootRig;
    private Transform rightuplegRig;
    private Transform rightlegRig;
    private Transform rightfootRig;

    private void Awake() {
        photonView = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        XROrigin rig = FindObjectOfType<XROrigin>();

        // Hier werden die jeweiligen Transforms für alle Spieler gefunden
        armatureRig             = rig.transform.Find("RPM_Player_J/Armature");
        hipsRig                 = rig.transform.Find("RPM_Player_J/Armature/Hips");
        spineRig                = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine");
        spine1Rig               = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1");
        spine2Rig               = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2");
        neckRig                 = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/Neck");
        headRig                 = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/Neck/Head");
        headtopRig              = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/Neck/Head/HeadTop_End");
        lefteyeRig              = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/Neck/Head/LeftEye");
        righteyeRig             = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/Neck/Head/RightEye");
        leftshoulderRig         = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/LeftShoulder");
        leftarmRig              = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/LeftShoulder/LeftArm");
        leftforarmRig           = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/LeftShoulder/LeftArm/LeftForeArm");
        lefthandRig             = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/LeftShoulder/LeftArm/LeftForeArm/LeftHand");
        rightshoulderRig        = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/RightShoulder");
        rightarmRig             = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/RightShoulder/RightArm");
        rightforarmRig          = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/RightShoulder/RightArm/RightForeArm");
        righthandRig            = rig.transform.Find("RPM_Player_J/Armature/Hips/Spine/Spine1/Spine2/RightShoulder/RightArm/RightForeArm/RightHand");
        leftuplegRig            = rig.transform.Find("RPM_Player_J/Armature/Hips/LeftUpLeg");
        leftlegRig              = rig.transform.Find("RPM_Player_J/Armature/Hips/LeftUpLeg/LeftLeg");
        leftfootRig             = rig.transform.Find("RPM_Player_J/Armature/Hips/LeftUpLeg/LeftLeg/LeftFoot");
        rightuplegRig           = rig.transform.Find("RPM_Player_J/Armature/Hips/RightUpLeg");
        rightlegRig             = rig.transform.Find("RPM_Player_J/Armature/Hips/RightUpLeg/RightLeg");
        rightfootRig            = rig.transform.Find("RPM_Player_J/Armature/Hips/RightUpLeg/RightLeg/RightFoot");

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
            armature.gameObject.SetActive(false);
            hips.gameObject.SetActive(false);
            spine.gameObject.SetActive(false);
            spine1.gameObject.SetActive(false);
            spine2.gameObject.SetActive(false);
            neck.gameObject.SetActive(false);
            head.gameObject.SetActive(false);
            headtop.gameObject.SetActive(false);
            lefteye.gameObject.SetActive(false);
            righteye.gameObject.SetActive(false);
            leftshoulder.gameObject.SetActive(false);
            leftarm.gameObject.SetActive(false);
            leftforarm.gameObject.SetActive(false);
            lefthand.gameObject.SetActive(false);
            rightshoulder.gameObject.SetActive(false);
            rightarm.gameObject.SetActive(false);
            rightforarm.gameObject.SetActive(false);
            righthand.gameObject.SetActive(false);
            leftupleg.gameObject.SetActive(false);
            leftleg.gameObject.SetActive(false);
            leftfoot.gameObject.SetActive(false);
            rightupleg.gameObject.SetActive(false);
            rightleg.gameObject.SetActive(false);
            rightfoot.gameObject.SetActive(false);

            // Hiermit werden die Positionen der einzelnen Körperteile mit den Positionen des XR-Rigs gleichgesetzt
            MapPosition(armature, armatureRig);
            MapPosition(hips, hipsRig);
            MapPosition(spine, spineRig);
            MapPosition(spine1, spine1Rig);
            MapPosition(spine2, spine2Rig);
            MapPosition(neck, neckRig);
            MapPosition(head, headRig);
            MapPosition(headtop, headtopRig);
            MapPosition(lefteye, lefteyeRig);
            MapPosition(righteye, righteyeRig);
            MapPosition(leftshoulder, leftshoulderRig);
            MapPosition(leftarm, leftarmRig);
            MapPosition(leftforarm, leftforarmRig);
            MapPosition(lefthand, lefthandRig);
            MapPosition(rightshoulder, rightshoulderRig);
            MapPosition(rightarm, rightarmRig);
            MapPosition(rightforarm, rightforarmRig);
            MapPosition(righthand, righthandRig);
            MapPosition(leftupleg, leftuplegRig);
            MapPosition(leftleg, leftlegRig);
            MapPosition(leftfoot, leftfootRig);
            MapPosition(rightupleg, rightuplegRig);
            MapPosition(rightleg, rightlegRig);
            MapPosition(rightfoot, rightfootRig);

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
