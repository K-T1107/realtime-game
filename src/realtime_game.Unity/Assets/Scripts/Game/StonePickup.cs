using UnityEngine;

public class StonePickup : MonoBehaviour
{
    public float pickupRange = 2f;
    public int maxStoneCount = 1;

    int currentStoneCount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickupStone();
        }
    }

    void TryPickupStone()
    {
        if (currentStoneCount >= maxStoneCount) return;

        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            pickupRange
        );

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Stone"))
            {
                Pickup(hit.gameObject);
                break;
            }
        }
    }

    void Pickup(GameObject stone)
    {
        currentStoneCount++;

        // ‚Ğ‚Æ‚Ü‚¸Á‚·‚¾‚¯
        Destroy(stone);

        Debug.Log("Î‚ğE‚Á‚½I");
    }

    // E‚¦‚é”ÍˆÍ‚ğ‰Â‹‰»
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}