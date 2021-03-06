using UnityEngine;

public class GroundTile : MonoBehaviour
{


    GroundSpawner groundSpawn;
    [SerializeField] GameObject cigarettePrefab;
    [SerializeField] GameObject speedUpPowerUp;
    [SerializeField] GameObject speedDownPowerUp;
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
        if (other.gameObject.name == "Player")
        {
            groundSpawn.SpawnNextTile(true);
            Destroy(gameObject, 2);
        }
        
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


    public void SpawnCigarettes()
    {
        int amountOfCigarettes = 3;
        for (int i = 0; i < amountOfCigarettes; i++)
        {
            GameObject temp = Instantiate(cigarettePrefab, transform);
            temp.transform.position = SpawnPoint(GetComponent<Collider>());
        }
    }
    public void SpawnPowerUps()
    {
        GameObject temp;
        int whichPowerUpToSpawn = Random.Range(0, 5);
        if (whichPowerUpToSpawn == 1)
        {
            temp = Instantiate(speedUpPowerUp, transform);
            temp.transform.position = SpawnPoint(GetComponent<Collider>());
        }
         else if(whichPowerUpToSpawn == 2)
        {
            temp = Instantiate(speedDownPowerUp, transform);
            temp.transform.position = SpawnPoint(GetComponent<Collider>());
        } else
        {
            return;
        }
    }
    Vector3 SpawnPoint(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = SpawnPoint(collider);
        }
        point.y = 1;
        return point;
    }
}
