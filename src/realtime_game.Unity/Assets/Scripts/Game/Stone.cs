using UnityEngine;

public class Stone : MonoBehaviour
{
    public float bouncePower = 5f;
    public float speedDecay = 0.8f;

    int bounceCount = 0;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // ���ɓ���������
        if (collision.gameObject.CompareTag("Water"))
        {
            // �������Ȃ疳���i���ށj
            if (rb.linearVelocity.y < -1f)
                return;

            Bounce();
        }
    }

    void Bounce()
    {
        Vector3 vel = rb.linearVelocity;

        // ������ɒ��˂�����
        vel.y = bouncePower;

        // ��������
        vel *= speedDecay;

        rb.linearVelocity = vel;

        bounceCount++;
        Debug.Log("Bounce Count: " + bounceCount);
    }
}
