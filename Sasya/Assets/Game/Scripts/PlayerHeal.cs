
using UnityEngine;

namespace Purgatory
{
    public class PlayerHeal : MonoBehaviour
    {
        public void ActivateHealUIFeedback()
        {
            this.gameObject.SetActive(true);
        }

        public void DisableHealUIFeedback()
        {
            this.gameObject.SetActive(false);
        }
    }

}
