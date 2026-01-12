using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [Header("Stone Settings")]
    public GameObject stonePrefab;
    public int spawnCount = 20;

    [Header("Spawn Area")]
    public Vector3 spawnAreaSize = new Vector3(10f, 1f, 10f);

    void Start()
    {
        SpawnStones();
    }

    void SpawnStones()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomPos = GetRandomPosition();
            Instantiate(stonePrefab, randomPos, Random.rotation);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 center = transform.position;

        float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float y = Random.Range(0, spawnAreaSize.y);
        float z = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);

        return center + new Vector3(x, y, z);
    }

    // エディタで範囲を見えるようにする
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
