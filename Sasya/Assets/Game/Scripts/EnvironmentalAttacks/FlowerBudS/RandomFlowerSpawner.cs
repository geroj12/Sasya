using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Purgatory
{
    public class RandomFlowerSpawner : MonoBehaviour
    {
        public string spawnPointTag = "something";
        public List<GameObject> prefabsToSpawn;

        private void OnEnable()
        {
            StartCoroutine(spawnFlowers());
        }
        private void OnDisable()
        {
            StopCoroutine(spawnFlowers());
        }

        IEnumerator spawnFlowers()
        {          
           GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnPointTag);
           foreach (GameObject spawnPoint in spawnPoints)
           {
              int randomPrefab = Random.Range(0, prefabsToSpawn.Count);
             
              int spawnOrNot = Random.Range(0, 1);
              if (spawnOrNot == 0)
              {
                  GameObject pts = Instantiate(prefabsToSpawn[randomPrefab]);
                  pts.transform.position = spawnPoint.transform.position;
              }
              yield return new WaitForSeconds(2f);   
           }               
        }
    }
}

