using UnityEngine;

public class Stone : MonoBehaviour
{
    public float bouncePower = 4.5f;
    public float speedDecay = 0.92f;
    public int maxBounceCount = 7;
    public float minForwardSpeed = 1.5f;

    int bounceCount = 0;
    bool canBounce = true;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Water"))
            return;

        if (!canBounce)
            return;

        // 横方向の勢い（前進）が足りなければ終了
        Vector3 horizontalVel = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        if (horizontalVel.magnitude < minForwardSpeed)
        {
            Sink();
            return;
        }

        if (bounceCount >= maxBounceCount)
        {
            Sink();
            return;
        }

        Bounce();
    }

    void Bounce()
    {
        canBounce = false;

        Vector3 vel = rb.linearVelocity;

        vel.y = bouncePower;        // 上に跳ねる
        vel *= speedDecay;          // 減速

        rb.linearVelocity = vel;
        rb.angularVelocity = Vector3.zero;

        bounceCount++;
        Debug.Log("Bounce: " + bounceCount);

        Invoke(nameof(ResetBounce), 0.2f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Sink();
        }
    }

    void ResetBounce()
    {
        canBounce = true;
    }

    void Sink()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        Debug.Log("Sink");
    }
}