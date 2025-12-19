using UnityEngine;

public class ThrowAngleController : MonoBehaviour
{
    public Transform throwPoint;

    public float sensitivity = 2f;
    public float minAngle = -10f;
    public float maxAngle = 45f;

    float currentAngle = 15f;

    void Start()
    {
        UpdateAngle();
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        currentAngle -= mouseY * sensitivity;
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        UpdateAngle();
    }

    void UpdateAngle()
    {
        throwPoint.localRotation = Quaternion.Euler(currentAngle, 0f, 0f);
    }
}
