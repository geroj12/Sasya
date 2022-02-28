using UnityEngine;

namespace Purgatory
{
    public class Enemy_Bullet_Health : MonoBehaviour
    {
        public float damage = 5;
        public float maxHealth = 10;
        public float currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        void GetDamage()
        {
            currentHealth -= damage;
        }

        void DestroyBullet()
        {
            Destroy(this.gameObject);
        }

        private void Update()
        {
            if (currentHealth <= 0)
            {
                DestroyBullet();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {              
                GetDamage();
                Player player = other.transform.gameObject.GetComponent<Player>();

                if (this.gameObject.CompareTag("Enemy_Bullet_ND"))
                {

                    Debug.Log("ND BUllet hit");
                    player.TakeDamage(damage);
                }
                else
                {
                    player.TakeDamage(damage);                   
                }
            }

            if (other.CompareTag("Player_Bullet") && !this.gameObject.CompareTag("Enemy_Bullet_ND"))
            {
                GetDamage();
            }

        }
    }

}
