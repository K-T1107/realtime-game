using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public static float sensitivity = 2f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        if (Mathf.Abs(mouseX) > 0.01f)
            Debug.Log("MouseX: " + mouseX);

        transform.Rotate(Vector3.up * mouseX);
    }
}