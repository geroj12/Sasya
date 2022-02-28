using UnityEngine;
using System.Collections;


namespace Purgatory
{
    public class RandomProjectileSpawner : MonoBehaviour
    {
        public int amountToSpawn = 0;
        public GameObject fallingProjectile;
        public int xPos;
        public int zPos;
        public int projectileCount;
        

        private void OnEnable()
        {
            StartCoroutine(FallingProjectileSpawnPoint());     
        }

        private void OnDisable()
        {
            StopCoroutine(FallingProjectileSpawnPoint());
        }


        IEnumerator FallingProjectileSpawnPoint()
        {
            while (projectileCount < amountToSpawn)
            {
                xPos = Random.Range(-50, 50);
                zPos = Random.Range(-50, 50);
                Instantiate(fallingProjectile, new Vector3(xPos, 60, zPos), Quaternion.identity);
                yield return new WaitForSeconds(2f);
                projectileCount += 1;
            }
        }
    }
}

