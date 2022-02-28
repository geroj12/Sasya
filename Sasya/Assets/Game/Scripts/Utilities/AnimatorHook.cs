using System.Collections.Generic;
using UnityEngine;

namespace Purgatory
{
    public class AnimatorHook : MonoBehaviour
    {      
        [SerializeField] private LookAtPlayer rotationBoss;

        [Header("Variables for Boss")]
        public bool canRotate;

        [HideInInspector]
        public Vector3 lookAtPosition;

        private void Start()
        {
            DisableRotation();
        }      
       

        //HANDLE ROTATION OF BOSS
        public void EnableRotation()
        {
            //Debug.Log("ENABLE ROTATION");
            rotationBoss.EnableningRotation();
        }
        public void DisableRotation()
        {
            //Debug.Log("DISABLE ROTATION");
            rotationBoss.DisableningRotation();
        }

        
       
        #region Trigger Bossenemy Shoot Functions On Animationevent
        public GameObject[] attacks;
        public void EnableBossAttack(int number)
        {
            //FindObjectOfType<Audio>().Play("BossShoot");
            attacks[number].SetActive(true);
        }

        public void DisableBossAttack(int number)
        {
            //FindObjectOfType<Audio>().StopPlaying("BossShoot");
            attacks[number].SetActive(false);
        }    
        #endregion

    }
}
