using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class Shoot : MonoBehaviour
    {
        public float shootspace;
        public float shootintensity;
        private float shootcounter;

        [SerializeField]
        private Transform shootposition;
        [SerializeField]
        private Transform muzzleflashposition;
        [SerializeField]
        private GameObject muzzleflash;

        [SerializeField] private GameObject playerBulletResourceAttackDefault;

        private void Start()
        {
            
        }

        private void Update()
        {
            shootcounter -= Time.deltaTime;

        }

        IEnumerator PlayShootSound()
        {
            FindObjectOfType<Audio>().PlayOneShot("PlayerShoot");
            yield return new WaitForSeconds(1f);
            
            
        }

       

        public void TriggerProjectileDefault()
        {
            if (shootcounter <= 0)
            {
                StartCoroutine(PlayShootSound());
                shootcounter = shootspace;
                GameObject bl = Instantiate(playerBulletResourceAttackDefault, shootposition.position, transform.rotation);
                Instantiate(muzzleflash, muzzleflashposition.position, transform.rotation);
                bl.transform.Rotate(0, 0, 0);
                Rigidbody rb = bl.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * shootintensity);
                Destroy(bl, 6.0f);

            }
        }

    }
}
