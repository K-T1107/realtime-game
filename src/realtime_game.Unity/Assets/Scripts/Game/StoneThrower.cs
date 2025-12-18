using UnityEngine;

public class StoneThrower : MonoBehaviour
{
    public GameObject stonePrefab;
    public Transform throwPoint;
    public float throwPower = 10f;

    StoneInventory inventory;

    void Start()
    {
        inventory = GetComponent<StoneInventory>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ç∂ÉNÉäÉbÉN
        {
            Throw();
        }
    }

    void Throw()
    {
        if (!inventory.HasStone()) return;

        GameObject stone = Instantiate(
            stonePrefab,
            throwPoint.position,
            Quaternion.identity
        );

        Rigidbody rb = stone.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwPower, ForceMode.Impulse);

        inventory.UseStone();
    }
}
