using UnityEngine;

namespace Purgatory
{
    public class Shooter : MonoBehaviour
    {
        public Rigidbody shotTemplate;
        public float speed;

        public void Shoot(float angle)
        {
            FindObjectOfType<Audio>().PlayOneShot("BossShoot");
            var direction = Quaternion.Euler(0, angle, 0) * transform.forward;
            var newShot = Instantiate(shotTemplate, transform.position, transform.rotation);
            newShot.velocity = direction * speed;
        }
    }

}
