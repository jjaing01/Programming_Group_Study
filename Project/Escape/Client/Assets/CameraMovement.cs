using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeViewCamera : MonoBehaviour
{
    public float moveSpeed = 10.0f; // Speed of camera movement
    public float lookSpeed = 2.0f; // Speed of camera rotation
    public float maxLookAngle = 85f; // Maximum angle the camera can look up or down

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input for rotation
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        rotationY -= Input.GetAxis("Mouse Y") * lookSpeed;

        // Clamp the vertical rotation to prevent flipping
        rotationY = Mathf.Clamp(rotationY, -maxLookAngle, maxLookAngle);

        // Apply the rotation to the camera
        transform.eulerAngles = new Vector3(rotationY, rotationX, 0.0f);

        // Get keyboard input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move the camera
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = transform.TransformDirection(direction); // Transform direction from local to world space
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
