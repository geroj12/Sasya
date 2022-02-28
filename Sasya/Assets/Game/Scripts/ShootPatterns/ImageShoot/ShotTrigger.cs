using UnityEngine;

namespace Purgatory
{
    public class ShotTrigger : MonoBehaviour
    {
        public Shooter shooter;

        private void Update()
        {
            transform.Translate(Vector3.right * Time.deltaTime * 3);
        }

        private void OnTriggerEnter(Collider other)
        {
            print(other.gameObject.name);
            shooter.Shoot(other.transform.position.z);
        }
    }

}
