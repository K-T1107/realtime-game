using UnityEngine;

public class Frisbee : MonoBehaviour
{
    Rigidbody rb;

    public float spinPower = 15f;
    public float liftForce = 0.3f;
    public float maxLifeTime = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // ��]�i�W���C�����ʁj
        rb.AddTorque(transform.forward * spinPower, ForceMode.Impulse);

        // �������Łi�y�ʉ��j
        Destroy(gameObject, maxLifeTime);
    }

    void FixedUpdate()
    {
        // �O�����̑��x�ɉ����ėg�͂�������
        Vector3 lift = Vector3.up * rb.linearVelocity.magnitude * liftForce;
        rb.AddForce(lift);
    }
}