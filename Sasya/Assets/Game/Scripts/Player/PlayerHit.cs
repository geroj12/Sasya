using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class PlayerHit : MonoBehaviour
    {       
        public void ActivateHitUIFeedback()
        {
            this.gameObject.SetActive(true);
        }

        public void DisableHitUIFeedback()
        {
            this.gameObject.SetActive(false);
        }
    }
}
