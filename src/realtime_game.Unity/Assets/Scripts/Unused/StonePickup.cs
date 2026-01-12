using UnityEngine;

public class StonePickup : MonoBehaviour
{
    public float pickupRange = 2f;

    StoneInventory inventory;

    void Start()
    {
        inventory = GetComponent<StoneInventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickupStone();
        }
    }

    void TryPickupStone()
    {
        if (!inventory.CanAddStone()) return;

        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            pickupRange
        );

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Stone"))
            {
                inventory.AddStone();
                Destroy(hit.gameObject);
                break;
            }
        }
    }
}
