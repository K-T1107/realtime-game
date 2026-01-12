using UnityEngine;

public class Target : MonoBehaviour
{
    public int score = 10;

    private bool hit = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Frisbee"))
        {
            ScoreManager.Instance.AddScore(score);
        }
    }
}