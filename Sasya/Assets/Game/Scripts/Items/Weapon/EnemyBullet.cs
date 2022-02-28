using UnityEngine;

namespace Purgatory
{
    public class EnemyBullet : MonoBehaviour
    {
        public float damage = 5;
        [SerializeField]
        private Animator anim;
        [SerializeField]
        private Collider collider;



        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Obstacles"))
            {
                if (this.gameObject.CompareTag("Enemy_Bullet"))
                {
                    Destroy_bullet();

                }
                else if (this.gameObject.CompareTag("Enemy_Bullet_ND")) {
                    Kill();
                }
            }

            if (other.CompareTag("Player_Bullet") && !this.gameObject.CompareTag("Enemy_Bullet_ND"))
            {
                Destroy_bullet();
                anim.SetTrigger("hit");
            }
            else if (other.CompareTag("Player_Bullet") && this.gameObject.CompareTag("Enemy_Bullet_ND"))
            {
                anim.SetTrigger("hit");
            }

        }

        void Destroy_bullet() {
            //anim.SetTrigger("hit");
            anim.SetTrigger("destroyed");
            collider.enabled = false;
        }

        void Kill() {
            Destroy(this.gameObject);
        }
    }

}
