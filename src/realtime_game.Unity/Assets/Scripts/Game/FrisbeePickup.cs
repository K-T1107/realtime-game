using UnityEngine;

public class FrisbeePickup : MonoBehaviour
{
    public int addCount = 1;

    void OnTriggerEnter(Collider other)
    {
        PlayerInventory inventory = other.GetComponent<PlayerInventory>();
        if (inventory == null) return;

        inventory.AddThrow(addCount);
        Destroy(gameObject);
    }
}