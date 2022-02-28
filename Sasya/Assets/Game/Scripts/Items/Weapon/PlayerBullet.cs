using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class PlayerBullet : MonoBehaviour
    {
        [SerializeField]
        private GameObject explosionVFX;
        [SerializeField]
        private GameObject despawnVFX;
        public float damage = 5;
        [SerializeField]
        private float despawnTime;
        private float timeTillDespawn;


        private void Update() {
            timeTillDespawn += Time.deltaTime;

            if (timeTillDespawn >= despawnTime) {
                Destroy(this.gameObject);
                Instantiate(despawnVFX, transform.position, Quaternion.identity);
            }

        
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Boss ai = other.transform.gameObject.GetComponent<Boss>();
                ai.TakeDamage(damage);
                SpawnExplosion();
                Destroy(this.gameObject);
            }
            else if (other.CompareTag("Enemy_Bullet") || other.CompareTag("Flower"))
            {
                FindObjectOfType<Audio>().PlayOneShot("BulletExplosion");
                SpawnExplosion();
                Destroy(this.gameObject);
            }
            
        }
        void SpawnExplosion() {
            var newShot = Instantiate(explosionVFX, transform.position, Quaternion.identity);            
        }
    }
}
