using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float height = 1.6f;

    void LateUpdate()
    {
        transform.position = target.position + Vector3.up * height;
    }
}