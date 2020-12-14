using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public int platformSpawnCount;

    public Vector3 lastEndPoint;
    
   

    public void SpawnPlatforms()
    {
        //8 times
        for (int i = 0; i < platformSpawnCount; i++)
        {
            GameObject platform = GameObject.Instantiate(platformPrefabs[Random.Range(0,platformPrefabs.Length)]);
            Platform platformScript = platform.GetComponent<Platform>();

            platform.transform.position = lastEndPoint;
            
            lastEndPoint = platformScript.ReturnEndPoint();

        }

    }
  
    private void Awake()
    {
        //reference
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlatforms();
    }
    private void FixedUpdate()
    {

    }

}
