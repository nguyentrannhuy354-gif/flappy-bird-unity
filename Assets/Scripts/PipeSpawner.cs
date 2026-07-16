using Unity.Mathematics;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] //de hien thi trong Inspector
    private GameObject pipePrefab;
    [SerializeField] private GameObject[] cloudPrefabs;

    [SerializeField]
    private float spawnRate = 1.2f;

    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 1f;

    public void Start()
    {
        // ham lap lai InvokeRepeating(tên_hàm, thời_gian_chờ, khoảng_lặp);
        InvokeRepeating("SpawnPipe", 0f, spawnRate);

        //dam may
        InvokeRepeating("spawnCloud", 0f, 5f);
    }

    private void SpawnPipe()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.y = UnityEngine.Random.Range(minY, maxY);

        //tao mot ban sao cua pipePrefab 
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }

    private void spawnCloud()
    {
        Vector3 cloudPosition = new Vector3(11, 4, 0);
        int randomIndex = UnityEngine.Random.Range(0, cloudPrefabs.Length - 1);
        Instantiate(cloudPrefabs[randomIndex], cloudPosition, quaternion.identity);
    }

    public void stopSpawn()
    {
        CancelInvoke();
    }
}