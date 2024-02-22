using UnityEngine;

public class BrendanMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the camera moves
    public float sensitivity = 2f; // Mouse sensitivity
    public bool invertY = false; // Whether to invert the vertical mouse movement

    private float verticalRotation = 0f;

    private void Update()
    {
        // Handle camera rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * (invertY ? -1f : 1f);

        transform.Rotate(Vector3.up, mouseX);

        // Calculate vertical rotation
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        // Apply rotation to camera
        transform.localRotation = Quaternion.Euler(verticalRotation, transform.localRotation.eulerAngles.y, 0f);

        // Handle camera movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontalMovement + transform.forward * verticalMovement;
        moveDirection.y = 0f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
