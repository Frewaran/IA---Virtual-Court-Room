using UnityEngine;

[System.Serializable]
public class MapTransform
{
    public Transform vrTarget;
    public Transform IkTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void MapVrAvatar()
    {
        IkTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        IkTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class AvatarController : MonoBehaviour
{
    [SerializeField] private MapTransform head;
    [SerializeField] private MapTransform leftHand;
    [SerializeField] private MapTransform rightHand;

    [SerializeField] private float turnSmoothness;
    [SerializeField] private Transform IkHead;
    [SerializeField] private Vector3 headBodyOffset;

    private void LateUpdate()
    {
        transform.position = IkHead.position + headBodyOffset;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(IkHead.forward, Vector3.up).normalized, Time.deltaTime * turnSmoothness);
        head.MapVrAvatar();
        leftHand.MapVrAvatar();
        rightHand.MapVrAvatar();
    }
}
