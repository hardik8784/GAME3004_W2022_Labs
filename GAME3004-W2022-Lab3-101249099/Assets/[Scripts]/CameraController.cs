using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Player Camera Properties")]
    public float MouseSensitivity = 10.0f;
    public Transform PlayerBody;

    private float XRotation = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        XRotation -= MouseY;
        XRotation = Mathf.Clamp(XRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(XRotation, 0.0f, 0.0f);
        PlayerBody.Rotate(Vector3.up * MouseX);
    }
}
