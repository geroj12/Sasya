using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class FlowerBudShooting : MonoBehaviour
    {
        
        public void ShootingMissle()
        {
            StartCoroutine(Shooting());
            
        }

        private IEnumerator Shooting()
        {
            yield return new WaitForSeconds(1f);            
        }
    }
}
