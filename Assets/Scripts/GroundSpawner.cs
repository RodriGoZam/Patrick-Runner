using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{   

    public Transform player;

    public GameObject groundTile;
    public GameObject[] obstacles;
    Vector3 nextSpawnPoint;
    public int numberOfTiles = 8;

    private List <GameObject> activeTiles = new List<GameObject>();
    private List <GameObject> activeObstacles = new List<GameObject>();
    private GameObject temp;
    // Start is called before the first frame update

    void SpawnTile()
    {
        temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        activeTiles.Add(temp);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
            SpawnObstacles();
            if (i > 0)
            {
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > 5+nextSpawnPoint.z - ((numberOfTiles-1) * 10))
        {
            SpawnTile();
            SpawnObstacles(); 
            destroyTile();
        }
    }

    private void destroyTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        Destroy(activeObstacles[0]);
        activeObstacles.RemoveAt(0);
    }

    void SpawnObstacles()
    {
        int spawnIndex = Random.Range(2, 5);
        
        Transform spawnPoint = temp.transform.GetChild(spawnIndex).transform;
        //Debug.Log("Spawn Index: " + spawnPoint);

        int obstacleIndex = Random.Range(0, 2);
        Debug.Log("Obstacle: " + obstacleIndex);

        GameObject obs = Instantiate(obstacles[obstacleIndex], spawnPoint.position, Quaternion.identity, transform);
        activeObstacles.Add(obs);
    }
}
