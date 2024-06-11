using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Ensure only the main camera is active at the start
        mainCamera.enabled = true;
        debugCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Switch cameras when the Tab key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mainCamera.enabled = !mainCamera.enabled;
            debugCamera.enabled = !debugCamera.enabled;

            // Lock and hide the cursor when the debug camera is active
            // , and unlock and show it when the main camera is active
            if (debugCamera.enabled)
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
    }

    public Camera mainCamera;
    public Camera debugCamera;
}
