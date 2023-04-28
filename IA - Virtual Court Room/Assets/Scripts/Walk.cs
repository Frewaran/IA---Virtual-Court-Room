using UnityEngine;

public class Walk : MonoBehaviour {
    public float speed = 6.0f;

    CharacterController characterController;

    void Start() {
        characterController = GetComponent<CharacterController>();
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;
        moveDirection.y = 0;
        moveDirection = moveDirection.normalized * speed;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
