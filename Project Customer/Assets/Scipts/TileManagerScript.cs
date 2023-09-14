using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_manager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    public float zSpawnPos = 3;
    public float tileLenght = 40;
    public int numberOfTiles = 3;
    private List<GameObject> activeTiles = new List<GameObject>();
    public int numberOfTiles = 4;

    public Transform playerTransform;

    void Start()
    {
        //tileLenght = tilePrefabs[0].;

        //first tiles
        for (int i = 0; i <= numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }

            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > zSpawnPos - tileLenght * numberOfTiles)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteOldTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject newTile = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawnPos, transform.rotation);
        activeTiles.Add(newTile);
        zSpawnPos += tileLenght;
    }

    private void DeleteOldTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
