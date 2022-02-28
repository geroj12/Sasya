using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Purgatory
{
    public class DetectionCollisionFlowerBud : MonoBehaviour
    {
        FlowerBudShooting flowerBud;
        [SerializeField]
        private GameObject missleProjectile;
        [SerializeField]
        private Animator anim;


        private void Start()
        {
            flowerBud = GetComponentInChildren<FlowerBudShooting>();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                missleProjectile.SetActive(true);
                flowerBud.ShootingMissle();
                anim.SetBool("open",true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                missleProjectile.SetActive(false);
                anim.SetBool("open", false);

            }
        }
    }
}
