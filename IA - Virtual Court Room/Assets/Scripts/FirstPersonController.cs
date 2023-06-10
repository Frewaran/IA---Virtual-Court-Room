using UnityEngine;

public class FirstPersonController : MonoBehaviour {
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float mouseSensitivity = 2.0f;

    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0.0f;


    void Start() {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        // Rotation
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0.0f, horizontalRotation, 0.0f);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90.0f, 90.0f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0.0f, 0.0f);

        // Movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * verticalMovement + transform.right * horizontalMovement;
        movement = movement.normalized * movementSpeed;

        characterController.Move(movement * Time.deltaTime);
    }
}
