using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public GameObject[] attackablePrefabs;
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


            int x = Random.Range(0, 10);
            
            if (x >= 8)
            {
                GameObject tree = GameObject.Instantiate(attackablePrefabs[Random.Range(0, attackablePrefabs.Length)]);
                {
                    tree.transform.position = lastEndPoint + new Vector3(0,2.7f,0);
                }
            }
            
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
