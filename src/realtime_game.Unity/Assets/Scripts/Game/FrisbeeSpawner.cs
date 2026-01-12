using UnityEngine;

public class FrisbeeSpawner : MonoBehaviour
{
    public GameObject frisbeePickupPrefab;
    public int spawnCount = 5;
    public float radius = 3f;

    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 pos = transform.position + Random.insideUnitSphere * radius;
            pos.y = transform.position.y;

            Instantiate(frisbeePickupPrefab, pos, Quaternion.identity);
        }
    }
}