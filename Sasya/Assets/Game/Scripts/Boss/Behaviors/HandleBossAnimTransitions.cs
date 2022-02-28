using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class HandleBossAnimTransitions : MonoBehaviour
    {
        [SerializeField] private Animator bossAnim;
        [SerializeField] private Boss boss;
        Animator myAnimator;
        [SerializeField] private Collider collider;
        // Start is called before the first frame update
        void Start()
        {
            this.myAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            SetBool();
            NextPhaseTransition();
            SetDiggingDown();
        }

        private void NextPhaseTransition()
        {
            if (bossAnim.GetBool("nextPhase") == true)
            {
                myAnimator.SetBool("nPhase", true);
                collider.enabled = false;
            }
        }     
    
        private void SetBool()
        {
            if (bossAnim.GetBool("healthUnder50") == true)
            {
                myAnimator.SetBool("hUnder50", true);
            }
        }

        private void SetDiggingDown()
        {
            if (boss.diggingDown == true)
            {
                Debug.Log("DIGGING DOWN");
                myAnimator.SetBool("diggingDown", true);
            }
        }

        
    }
}
