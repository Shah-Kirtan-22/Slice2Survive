using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> basePrefab; // A list of prefabs for the base
    private float spawnPosition = -10.0f; // Can start at zero if the player is positioned forward on the z axis
    private float prefabLength;
    public Transform player;
    private int prefabNumber = 3; //the number of prefabs to spawn ahead of time
    private float timer = 5.0f;

    [SerializeField]
    private List<GameObject> activePrefabs;

    private void Awake()
    {
        //prefabLength = Random.Range(50.5f, 54.0f); // The z scale is 5 and the mesh size is 10 for unity + 3.5 extra mesh size to provide enough space for the player to fall through
        prefabLength = 50.0f; 
    }

    private void Start()
    {
        activePrefabs = new List<GameObject>();
    }

    private void Update()
    {
        if(activePrefabs.Count <= 3)
        {
            SpawnBasePrefab(Random.Range(0, basePrefab.Count));
        }

        else if(activePrefabs.Count >= 4 && player.position.z > spawnPosition - (prefabNumber * prefabLength))
        {
            SpawnBasePrefab(Random.Range(0, basePrefab.Count));


            DestroyBasePrefab();
        }
    }

    private void SpawnBasePrefab(int prefabIndex)
    {
        GameObject go = Instantiate(basePrefab[prefabIndex], transform.forward * spawnPosition , transform.rotation);
        activePrefabs.Add(go);
        spawnPosition += prefabLength;
    }

    private void DestroyBasePrefab()
    {
        Destroy(activePrefabs[0]);
        activePrefabs.RemoveAt(0);

    }
}
