using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class CameraManager : MonoBehaviour
    {
        public Transform targetTransform;
        public Transform lockTarget;
        public Transform pivot;
        public Transform camTransform;
        float defaultPosition;
        float targetPosition;
        public float followSpeed = 0.1f;
        public float resetSpeed = 3;
        public float velSpeed = .1f;

        public float lookSpeed = .1f;
        public float pivotSpeed = .03f;

        Transform mTransform;
        Vector3 camTransPosition;
        public float camCollisionOffset = 0.2f;
        public float minCollisionOffset = 0.2f;
        public float camSphereRadius = 0.2f;

        float lookAngle;
        float pivotAngle;
        public float minPivot = -35;
        public float maxPivot = 35;

        LayerMask ignoreLayers;

        private void Start()
        {          
            mTransform = this.transform;
            defaultPosition = camTransform.localPosition.z;
            ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10 | 1 << 11);

        }

        public void FollowTarget(float delta)
        {
            Vector3 targetPosition = Vector3.Lerp(transform.position, targetTransform.position, delta / followSpeed);
            mTransform.position = targetPosition;
            HandleCollisions(delta);


        }
      

        void HandleCollisions(float delta)
        {
            targetPosition = defaultPosition;

            RaycastHit hit;
            Vector3 direction = camTransform.position - pivot.position;
            direction.Normalize();

            Collider[] colliders = Physics.OverlapSphere(camTransform.position, camSphereRadius,ignoreLayers);
            for (int i = 0; i < colliders.Length; i++)
            {
                Vector3 closetPoint = colliders[i].ClosestPoint(camTransform.position); //
                float dis = Vector3.Distance(pivot.position, closetPoint);
                targetPosition = dis;  //new distance to consider
                break; //should not affect to many colliders at the same time
            }

            //from pivot to camera
            if (Physics.SphereCast(pivot.position,camSphereRadius ,direction, out hit, Mathf.Abs(defaultPosition), ignoreLayers))
            {
                float dis = Vector3.Distance(pivot.position, hit.point);
                targetPosition = -(dis - camCollisionOffset);
            }
            

            if (Mathf.Abs(targetPosition) < minCollisionOffset)
            {
                targetPosition = -minCollisionOffset;
            }

            camTransPosition.z = Mathf.Lerp(camTransform.localPosition.z, targetPosition,delta / .2f);

            camTransform.localPosition = camTransPosition;
        }
    }
}

