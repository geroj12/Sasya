using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{

    public class Obstacle : MonoBehaviour
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

        private void Update()
        {
            if (currentHealth <= 0)
            {
                Kill();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy_Bullet") || other.CompareTag("Enemy_Bullet_ND"))
            {
                GetDamage();
            }
        }

        private void Kill()
        {
            Destroy(this.gameObject);
        }

    }
}
