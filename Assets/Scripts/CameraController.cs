using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float sensivity = 500;
    Transform playerBody;
    float xRotation = 0;

    private void Start()
    {
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        LookAround();
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        playerBody.Rotate( new Vector3(0, mouseX, 0) ); // Vector3.up * mouseX
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70, 60);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
