using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject product;
    [SerializeField] private List<GameObject> spawnPointList;
    private List<GameObject> availableSpawnPoints;
    void Start()
    {
        availableSpawnPoints = new List<GameObject>(spawnPointList);
        StartCoroutine("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            
            int index = UnityEngine.Random.Range(0, availableSpawnPoints.Count);
            Debug.Log(index);
            Vector3 pos = availableSpawnPoints[index].transform.position;
            spawnPointList.RemoveAt(index);
            Instantiate(product, pos, Quaternion.identity);
        }
    }
}
