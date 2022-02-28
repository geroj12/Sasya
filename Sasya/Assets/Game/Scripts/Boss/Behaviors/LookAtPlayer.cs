using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Purgatory
{
    public class LookAtPlayer : MonoBehaviour
    {
       [SerializeField]private Animator animator;
       [SerializeField]private NavMeshAgent agent;
       [SerializeField]private AnimatorHook animatorHook;
       [SerializeField]private Transform mTransform;

        public float fovRadius = 20;
        private bool bossRotation = false;

        Player currentTarget;
        bool isInteracting = false;

        private void Start()
        {
            mTransform = this.transform;        
        }

        private void Update()
        {
            isInteracting = animator.GetBool("isInteracting");
            if (currentTarget == null)
            {
                HandleDetection();
            }
            else
            {
                if (agent.isActiveAndEnabled)
                    agent.SetDestination(currentTarget.mTransform.position);

                if (!isInteracting && !bossRotation == true)
                {
                    agent.enabled = true;
                    mTransform.rotation = agent.transform.rotation;
                    Vector3 lookPosition = currentTarget.mTransform.position;
                    lookPosition.y = transform.position.y;
                    animatorHook.lookAtPosition = lookPosition;
                }
            }
        }

        void LateUpdate()
        {
            agent.transform.localPosition = Vector3.zero;
            agent.transform.localRotation = Quaternion.identity;

        }
       
            
        public void EnableningRotation()
        {
            bossRotation = false;
        }


        public void DisableningRotation()
        {
            bossRotation = true;
        }

        void HandleDetection()
        {
            Collider[] cols = Physics.OverlapSphere(mTransform.position, fovRadius);
            for (int i = 0; i < cols.Length; i++)
            {
                Player controller = cols[i].transform.GetComponentInParent<Player>();
                if (controller != null)
                {
                    currentTarget = controller;

                    return;
                }
            }
        }


    }
}
