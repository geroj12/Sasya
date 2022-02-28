using System.Collections;
using UnityEngine;

namespace Purgatory
{
    public class SlowMotionOnCollision : MonoBehaviour
    {
        [SerializeField]
        private float slowMotionWaitTime = 0.1f;
        [SerializeField]
        private float slowMotionForce = 0.4f;
        private IEnumerator SlowMotion()
        {
            Time.timeScale = 0.4f;
            yield return new WaitForSeconds(slowMotionWaitTime);
            Time.timeScale = 1f;
        }

        public void ActivateSlowMotion()
        {
            StartCoroutine(SlowMotion());
        }
    }

}
