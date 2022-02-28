using UnityEngine;

namespace Purgatory
{
    public class BossTrigger : MonoBehaviour
    {
        [SerializeField]
        private Animator anim;

        private void Start()
        {
            
        }

        //PLAYER ACTIVATES THE BOSS
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player_Bullet") || other.CompareTag("Player"))
            {
                anim.SetTrigger("bossTriggered");
            }
        }
    }
}
