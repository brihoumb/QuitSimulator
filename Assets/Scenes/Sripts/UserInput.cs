using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UserInput : MonoBehaviour
{
    private float rotX = 0f;
    private float rotY = 0f;
    private float speed = 0.1f;
    private float camSens = 3f;
    private float totalRun = 1.0f;
    private Vector3 lastMouse = new Vector3(0, 0, 0);

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotY += Input.GetAxis("Mouse X") * camSens;
        rotX += Input.GetAxis("Mouse Y") * camSens;
        rotX = Mathf.Clamp(rotX, -60f, 60f);
        lastMouse = new Vector3(-rotX, rotY, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        Vector3 p = GetBaseInput();
        totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
        p = (p * 100.0f) * Time.deltaTime;
        Vector3 newPosition = transform.position;
        transform.Translate(p);
        newPosition.x = transform.position.x;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }

    private Vector3 GetBaseInput()
    { 
        Vector3 p_Velocity = new Vector3();

        if (Input.GetKey(KeyCode.Z)) {
            p_Velocity += new Vector3(0, 0, speed);
        } else if (Input.GetKey(KeyCode.S)) {
            p_Velocity += new Vector3(0, 0, -speed);
        } else if (Input.GetKey(KeyCode.Q)) {
            p_Velocity += new Vector3(-speed, 0, 0);
        } else if (Input.GetKey(KeyCode.D)) {
            p_Velocity += new Vector3(speed, 0, 0);
        }
        return p_Velocity;
    }
}