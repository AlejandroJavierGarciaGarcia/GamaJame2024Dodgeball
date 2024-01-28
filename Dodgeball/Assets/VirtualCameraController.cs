using UnityEngine;

public class MouseCameraControl : MonoBehaviour
{
    public float sensitivity = 2.0f;  // Adjust this value to control the mouse sensitivity
    public Transform player;  // The player's transform
    public Transform cameraTransform;  // The camera's transform

    public Transform orientationTransform;

    private float rotationX = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player around the Y-axis based on mouse input
        player.Rotate(Vector3.up * mouseX * sensitivity);

        // Rotate the camera vertically based on mouse input
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);  // Limit the vertical rotation

        // Apply the rotation to the camera
        cameraTransform.rotation = Quaternion.Euler(rotationX, player.eulerAngles.y, 0);

        // Face the player toward the camera direction
        orientationTransform.forward = cameraTransform.forward;
    }
}
