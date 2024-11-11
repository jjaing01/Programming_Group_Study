using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera debugCamera;

    public delegate void OnCameraSwitch();
    public static event OnCameraSwitch CameraSwitchEvent;

    private bool isDebugCameraActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure only the main camera is active at the start
        mainCamera.enabled = true;
        debugCamera.enabled = false;

        CameraSwitchEvent += SwitchCameras;
    }

    // Update is called once per frame
    void Update()
    {
        // Switch cameras when the Tab key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CameraSwitchEvent?.Invoke();
        }
    }

    private void SwitchCameras()
    {
        // Toggle the Camera activation states
        isDebugCameraActive = !(isDebugCameraActive);

        mainCamera.enabled = !(isDebugCameraActive);
        debugCamera.enabled = isDebugCameraActive;

        // Lock and hide the cursor when the debug camera is active
        // , and unlock and show it when the main camera is active
        if (isDebugCameraActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnDestroy()
    {
        CameraSwitchEvent -= SwitchCameras;
    }
}
