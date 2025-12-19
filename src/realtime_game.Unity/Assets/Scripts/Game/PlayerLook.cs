using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 2f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * sensitivity);
    }
}