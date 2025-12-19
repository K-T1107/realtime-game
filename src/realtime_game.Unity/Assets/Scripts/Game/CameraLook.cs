using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform cameraRoot;
    public float sensitivity = 2f;

    // ÇŸÇ⁄ê^è„ÅEê^â∫Ç‹Ç≈OK
    public float minY = -89f;
    public float maxY = 89f;

    float xRotation = 0f;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation -= mouseY * sensitivity;
        xRotation = Mathf.Clamp(xRotation, minY, maxY);

        cameraRoot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}