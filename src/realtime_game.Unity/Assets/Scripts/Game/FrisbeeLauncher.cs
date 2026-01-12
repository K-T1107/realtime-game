using UnityEngine;

public class FrisbeeLauncher : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject frisbeePrefab;
    public PlayerInventory inventory;

    public float throwPower = 15f;

    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("左クリック検知");

            if (!inventory.CanThrow())
            {
                Debug.Log("投げられない：所持数0");
                return;
            }

            Debug.Log("投げる処理開始");
            ThrowFrisbee();
            inventory.UseThrow();
        }
    }

    void ThrowFrisbee()
    {
        GameObject frisbee = Instantiate(
            frisbeePrefab,
            throwPoint.position,
            throwPoint.rotation
        );

        Rigidbody rb = frisbee.GetComponent<Rigidbody>();

        Vector3 dir = throwPoint.forward;
        rb.AddForce(dir * throwPower, ForceMode.Impulse);
    }
}