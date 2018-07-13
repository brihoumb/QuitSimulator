using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Camera cam;
    private float rotX = 0f;
    private float rotY = 0f;
    private float maxX = 60f;
    private float minX = -60f;
    private float maxY = 360f;
    private float minY = -360f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKey(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Update()
    {
        rotY += Input.GetAxis("Mouse X") * 15f;
        rotX += Input.GetAxis("Mouse Y") * 15f;
        rotX = Mathf.Clamp(rotX, minX, maxX);
        transform.localEulerAngles = new Vector3(-rotX, rotY, 0);
        cam.transform.localEulerAngles = transform.localEulerAngles;
    }
}
