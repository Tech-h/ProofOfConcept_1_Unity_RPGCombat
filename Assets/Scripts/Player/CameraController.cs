using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform followTarget;

    [SerializeField] float rotationSpeedX = 2f;
    [SerializeField] float rotationSpeedY = 2f;
    [SerializeField] float cameraDistance = 5;

    [SerializeField] float minVerticalAngle = -45;
    [SerializeField] float maxVerticalAngle = 45;

    [SerializeField] bool invertX;
    [SerializeField] bool invertY;

    [SerializeField] Vector2 framingOffset;

    float rotY;
    float rotX;

    float invertXVal;
    float invertYVal;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;

        rotY += Input.GetAxis("Mouse X") * rotationSpeedX * invertXVal;

        rotX -= Input.GetAxis("Mouse Y") * rotationSpeedY * invertYVal;
        rotX = Mathf.Clamp(rotX, minVerticalAngle, maxVerticalAngle);

        var targetRotation = Quaternion.Euler(rotX, rotY, 0);

        var focusPosition = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);

        transform.position = focusPosition - targetRotation * new Vector3(0, 0, cameraDistance);
        transform.rotation = targetRotation;
    }

    public Quaternion PlanarRotation => Quaternion.Euler(0, rotY, 0);
}
