using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public static float sensitivity = 2f;
    public bool canLook = true;

    float xRotation = 0f;

    void Update()
    {
        if (!canLook) return;

        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
