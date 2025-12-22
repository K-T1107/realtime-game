using UnityEngine;

public class ForceFPSCamera : MonoBehaviour
{
        void LateUpdate()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}