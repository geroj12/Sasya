using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Purgatory
{
    public class Boss : MonoBehaviour
    {

        #region References
        new Rigidbody rigidbody;
        public Animator animator;
        NavMeshAgent agent;
        Transform mTransform;
        [SerializeField]
        private Animator vfxanimator;
        [SerializeField]
        private GameObject get_hit_particles;
        [SerializeField]
        private GameObject groundIndicatorPrefab;
        [SerializeField]
        private GameObject[] bossmodel;
        [SerializeField]
        private GameObject lights;
        [SerializeField]
        private ParticleSystem dig_trail;
        [SerializeField]
        private ParticleSystem dig_trail_dust;
        #endregion

        #region Variables
        //Healthbar
        [SerializeField] private float maxHealth = 100;
        [SerializeField] private float currentHealth;
        [SerializeField] private HealthBarBoss healthBar;

        //Movement
        bool setWandering = false;
        private int currentPhaseIdx = 0;
        public float moveSpeed = 2;
        public float startWaitTime;
        private float waitTime;
        public Transform[] moveSpots;
        private int randomSpot;
        [HideInInspector]
        public float recoveryTimer;

        public bool diggingDown = false;

        [SerializeField]
        private GameObject bulletPatterns;

        [SerializeField] private Collider collider;

        private bool animFinishedPlaying = false;

        [SerializeField] private float healthGainEachPhase = 0.0f;

        private GameObject groundIndicatorInstance;
        #endregion

        private void Start()
        {
            rigidbody = GetComponentInChildren<Rigidbody>();
            agent = GetComponentInChildren<NavMeshAgent>();
            mTransform = this.transform;

            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            waitTime = startWaitTime;
            randomSpot = Random.Range(0, moveSpots.Length);
            rigidbody.isKinematic = false;
        }

        private void Update()
        {
            if (animFinishedPlaying == true)
            {
                Debug.Log("WANDER");
                setWandering = true;
            }

            CheckHealthCondition();
            Die();

            if (setWandering)
            {
                Wander();
            }
            healthBar.SetHealth(currentHealth);
        }

        void LateUpdate()
        {
            agent.transform.localPosition = Vector3.zero;
            agent.transform.localRotation = Quaternion.identity;
        }


        //CHECKING BOSS HEALTH
        #region HEALTH CHECK
        private void CheckHealthCondition()
        {
            //IF CURRENTHEALTH IS UNDER 80...
            if (currentHealth <= 80)
            {
                //Debug.Log("Health under 80");
                animator.SetBool("healthUnder80", true);
            }

            //IF CURRENTHEALTH IS UNDER 50...
            if (currentHealth <= 50)
            {
                animator.SetBool("healthUnder50", true);
            }
        }
        #endregion

        //STARTS A NEW PHASE WITH MORE HEALTH,POWER
        #region NEW PHASE
        private void ToNextPhase()
        {
            healthBar.SetMaxHealth(maxHealth);
            currentPhaseIdx += 1;
            maxHealth += healthGainEachPhase;
            currentHealth = maxHealth;
            animator.SetBool("healthUnder80", false);
            animator.SetBool("healthUnder50", false);
            healthBar.EnterPhase(currentPhaseIdx, maxHealth);
            bulletPatterns.SetActive(false);
            StartCoroutine(WaitToSwap());
        }
        #endregion

        IEnumerator WaitToSwap()
        {

            yield return new WaitForSeconds(4.5f);
            currentModel += 1;

        }

        IEnumerator TimeToDeactivateModel()
        {
            yield return new WaitForSeconds(1f);
            bossmodel[0].SetActive(false);
            bossmodel[1].SetActive(false);
            bossmodel[2].SetActive(false);

        }

        private int currentModel = 0;
        //RANDOM MOVEMENT TO SPECIFIC POINTS
        #region RANDOM MOVEMENT
        void Wander()
        {
            //MOVING RANDOMLY TO DEFINED SPOTS

            collider.enabled = false;
            var em = dig_trail.emission;
            em.enabled = true;
            var emdust = dig_trail_dust.emission;
            emdust.enabled = true;
            //dig_trail.GetComponent<ParticleSystem>().emission.enabled = true;
            lights.SetActive(false);
            Vector3 new_position = new Vector3(moveSpots[randomSpot].position.x, transform.position.y, moveSpots[randomSpot].position.z);
            transform.position = Vector3.MoveTowards(mTransform.position, new_position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(mTransform.position, new_position) < 0.2f)
            {

                //TIME INBETWEEN TO REACH NEW POSITION
                if (waitTime <= 0)
                {

                    //groundIndicatorInstance = Instantiate(groundIndicatorPrefab, new_position, Quaternion.identity);
                    bulletPatterns.SetActive(false);
                    collider.enabled = false;
                    randomSpot = Random.Range(0, moveSpots.Length);
                    groundIndicatorInstance = Instantiate(groundIndicatorPrefab, moveSpots[randomSpot].position, Quaternion.identity);
                    waitTime = startWaitTime;
                    diggingDown = true;
                    switch (currentModel)
                    {
                        case 1:
                            StartCoroutine(TimeToDeactivateModel());

                            break;
                        case 2:
                            StartCoroutine(TimeToDeactivateModel());

                            break;
                    }
                }
                //RANDOM SPOT REACHED -> WAIT -> ATTACK
                else
                {
                    
                    em.enabled = false;
                    emdust.enabled = false;
                    Destroy(groundIndicatorInstance);
                    lights.SetActive(true);
                    bulletPatterns.SetActive(true);
                    waitTime -= Time.deltaTime;
                    collider.enabled = true;
                    diggingDown = false;
                    switch (currentModel)
                    {
                        case 1:

                            bossmodel[1].SetActive(true);
                            break;
                        case 2:
                            bossmodel[1].SetActive(false);
                            bossmodel[2].SetActive(true);
                            break;
                    }
                }
            }
        }
        #endregion

        //DOES DAMAGE
        #region TakeDamage       
        public void TakeDamage(float damage)
        {
            FindObjectOfType<Audio>().PlayOneShot("BossGettingHurt");
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            Instantiate(get_hit_particles, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), Quaternion.identity);
            vfxanimator.SetTrigger("gethit");
        }
        #endregion

        //CHECK IF BOSS IS ALIVE
        #region Die
        public void Die()
        {
            if (currentHealth <= 0)
            {
                StartCoroutine(TimeForNextPhase());
                StartCoroutine(WaitTimeForAnimFinished());
                ToNextPhase();
            }
        }
        #endregion

        //BREAK TIME FOR NEXT PHASE
        #region Break Time For Next Phase
        IEnumerator TimeForNextPhase()
        {
            animator.SetBool("nextPhase", true);
            yield return new WaitForSeconds(0.005f);
            animator.SetBool("nextPhase", false);
        }

        IEnumerator WaitTimeForAnimFinished()
        {
            yield return new WaitForSeconds(10f);
            animFinishedPlaying = true;
        }
        #endregion
    }
}
