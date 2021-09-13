using UnityEngine;

public class GroundTile : MonoBehaviour
{


    GroundSpawner groundSpawn;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject obstacleHighPrefab;
    [SerializeField] float obstacleHighChance = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        groundSpawn = GameObject.FindObjectOfType<GroundSpawner>();

    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawn.SpawnNextTile(true);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/


    public void SpawnObstacle()
    {
        //Which one to spawn
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if(random < obstacleHighChance)
        {
            obstacleToSpawn = obstacleHighPrefab;
        }

        int obstSpawnIndex = Random.Range(2, 5);
        Transform spawnpoint = transform.GetChild(obstSpawnIndex).transform;

        Instantiate(obstacleToSpawn, spawnpoint.position, Quaternion.identity, transform);
    }


    public void SpawnCoins()
    {
        int amountOfCoins = 10;
        for (int i = 0; i < amountOfCoins; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = CoinSpawnPoint(GetComponent<Collider>());
        }
    }
    Vector3 CoinSpawnPoint(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = CoinSpawnPoint(collider);
        }
        point.y = 1;
        return point;
    }
}
