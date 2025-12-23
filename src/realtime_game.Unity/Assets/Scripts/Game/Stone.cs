using UnityEngine;

public class Stone : MonoBehaviour
{
    public float bouncePower = 4f;
    public float speedDecay = 0.8f;
    public int maxBounceCount = 7;
    public float minSpeed = 2.5f;

    int bounceCount = 0;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Water"))
            return;

        // 最大回数
        if (bounceCount >= maxBounceCount)
            Sink();

        // 速度不足
        if (rb.linearVelocity.magnitude < minSpeed)
            Sink();

        // 落下しすぎてたら沈む
        if (rb.linearVelocity.y < -1.0f)
            Sink();

        Bounce();
    }

    void Bounce()
    {
        Vector3 vel = rb.linearVelocity;

        vel.y = bouncePower;       // 上に跳ねる
        vel *= speedDecay;         // 減速

        rb.linearVelocity = vel;
        rb.angularVelocity = Vector3.zero;

        bounceCount++;
        Debug.Log("Bounce: " + bounceCount);
    }

    void Sink()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true; // 完全停止
    }
}
