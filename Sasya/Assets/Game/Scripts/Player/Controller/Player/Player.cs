using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.AI;

namespace Purgatory
{
    public class Player : MonoBehaviour, IHaveAction
    {
        #region References
        [Header("Animator")]
        public Animator enemyAnimator;
        private Coroutine coroutineMovement;
        [SerializeField]
        private Animator anim;
        [SerializeField] private AnimationCurve movementCurve;
        public float accelerationTime;
        public float currentSpeed;

        [SerializeField] private NavMeshAgent navAgent;
        
        [Header("GAME UI")]
        [SerializeField] GameUI gameUI;

        Camera mainCamera;        
        PlayerControls keys;

        [Header("MOUSE INPUT/PLAYER ASSIGN")]
        public Vector3 mousePosition;
        [SerializeField]
        public Transform mTransform;

        [Header("VFX/POSITIONING")]
        public GameObject bloodSplash;
        public Transform effectSpawnTransform;
        #endregion

        #region Variables
        [Header("Health")]
        public float maxHealth = 100;
        public float currentHealth;
        public HealthBar healthBar;

        [Header("Movement")]
        public float movementSpeed = 4;
        Vector2 moveDirection;

        //[SerializeField]
        //private AreaDefinition walkableArea;
            
        [Header("Other")]
        public float invincibilityLength;
        private float invincibilityCounter;
        public bool isInteracting;
        public CinemachineImpulseSource hit_shake;
        #endregion

        #region Vorsicht
        public ItemActionContainer[] currentActions;
        public ItemActionContainer[] defaultActions;
        ItemActionContainer currentAction;

        InventoryManager _inventoryManager;
        public InventoryManager inventoryManager
        {
            get
            {
                return _inventoryManager;
            }
        }
        [SerializeField]
        private Shoot shoot;
        Vector3 currentNormal;

        ActionContainer _lastAction;
        public ActionContainer lastAction
        {
            get
            {
                if (_lastAction == null)
                {
                    _lastAction = new ActionContainer();
                }

                _lastAction.owner = mTransform;
                return _lastAction;
            }
        }

        public void InitInventory(PlayerProfile profile)
        {
            _inventoryManager.Init(profile, this);

        }

        #endregion

        public void Init()
        {
            mTransform = this.transform;

            _inventoryManager = GetComponent<InventoryManager>();
            shoot = GetComponentInChildren<Shoot>();

            ResetCurrentActions();
        }

        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            mainCamera = FindObjectOfType<Camera>();
            navAgent = GetComponent<NavMeshAgent>();
            RegisterMovementInput();
        }      

        private void Update()
        {
            
            isInteracting = anim.GetBool("isInteracting");

            mousePosition = Mouse.current.position.ReadValue();

            healthBar.SetHealth(currentHealth);

            HealthGain();
            CheckInvicibility();
        }

      
        private void RegisterMovementInput()
        {
            keys = new PlayerControls();
            keys.Player.Movement.performed += i => moveDirection = i.ReadValue<Vector2>();
            keys.Enable();
        }

        

        #region COLLISION CHECKS
        private void OnTriggerEnter(Collider other)
            {
                //TAKE DAMAGE FROM BOSS BULLETS
                if (other.CompareTag("Enemy_Bullet") || other.CompareTag("Enemy_Bullet_ND"))
                {
                    //FREEZE TIME AFTER DAMAGE
                    GetComponent<SlowMotionOnCollision>().ActivateSlowMotion();
                    TakeDamage(5f);
                }
            }
        #endregion

        #region IENUMERATOR
            //ACTIVATE HIT FEEDBACK UI
            IEnumerator PlayerHITFeedback()
            {
                gameUI.ActivateHitUIFeedback();
                yield return new WaitForSeconds(.2f);
                gameUI.DisableHitUIFeedback();
            }

            IEnumerator PlayerHealFeedback()
            {
                gameUI.ActivateHealUIFeedback();
                yield return new WaitForSeconds(0.3f);
                gameUI.DisableHealUIFeedback();
            }

            //TIME TO REACH MAX MOVEMENT SPEED ON THE CURVE
            private IEnumerator EvalueteCurve()
            {
                float currentTime = 0;
                while (currentTime < accelerationTime)
                {
                    currentSpeed = movementCurve.Evaluate(currentTime);
                    currentTime += Time.deltaTime;
                    yield return null;
                }
                yield return null;
            }
          

            private IEnumerator PlayerGettingHitSound()
            {
                FindObjectOfType<Audio>().PlayOneShot("PlayerGettingHurt");
                yield return new WaitForSeconds(1f);
           
        }
        #endregion

        #region GAIN HEALTH
        private void HealthGain()
            {
                //UPDATE CURRENTHEALTH WITH THE NEW PHASE
                if (enemyAnimator.GetBool("nextPhase") == true)
                {
                    currentHealth = maxHealth;
                    StartCoroutine(PlayerHealFeedback());
                }         
            }
        #endregion

        #region INVISIBILITY
            private void CheckInvicibility()
            {
                //X - SEC INVINCIBILITY AFTER EVERY SINGLE DAMAGE
                if (invincibilityCounter > 0)
                {
                    invincibilityCounter -= Time.deltaTime;
                }
            }
        #endregion
      
        #region TAKE DAMAGE       
        public void TakeDamage(float damage)
        {
            //DO DAMAGE AFTER INVICIBILITY
            if (invincibilityCounter <= 0)
            {
                hit_shake.GenerateImpulse();
                StartCoroutine(PlayerHITFeedback());
                BloodSplash();
                StartCoroutine(PlayerGettingHitSound());

                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);

                //SET TIME AFTER GETTING HIT TO NORMAL LENGTH
                invincibilityCounter = invincibilityLength;
            }
        }
        #endregion

        #region BLOOD EFFECT
        //INSTANTIATE BLOOD PREFAB 
        void BloodSplash()
        {
            Instantiate(bloodSplash, effectSpawnTransform.position, transform.rotation);
        }
        #endregion

        #region MOVEMENT

        public void MoveCharacter(float vertical, float horizontal)
        {
            LookAt();
            vertical = moveDirection.y;
            horizontal = moveDirection.x;

            Vector3 movement = new Vector3(horizontal, 0f, vertical);



            //IF KEY PRESSED -> MOVE
            if (movement.magnitude > 0)
            {
                
                if (coroutineMovement == null)
                {
                    coroutineMovement = StartCoroutine(EvalueteCurve());
                }

                movement.Normalize();
                movement *= currentSpeed * movementSpeed * Time.deltaTime;

                //if (walkableArea && !walkableArea.IsInsideArea(transform.position + movement)) {
                //    movement = walkableArea.MoveAlongAreaBorder(movement,transform.position);   
                //}
                
                navAgent.transform.Translate(movement, Space.World);
            }
            else
            {
                //StopCoroutine(coroutineMovement);
                coroutineMovement = null;
            }
        }
        #endregion

        #region LOOK AT MOUSE POSITION
        void LookAt()
        {
            //SHOOTS A RAY FROM CAMERA TO MOUSE POSITION
            Ray cameraRay = mainCamera.ScreenPointToRay(mousePosition);
            Plane groundPlane = new Plane(Vector3.up, transform.position);
            float rayLength;

            ////CAMERA AND MOUSE POSITION MEET AT ONE POINT ON THE PLANE
            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);
                //ROTATE THE GAME OBJECT TO THE POINT
                transform.LookAt(new Vector3(pointToLook.x, pointToLook.y, pointToLook.z));
            }
        }
        #endregion






        #region Items & Actions
        void ResetCurrentActions()
        {
            currentActions = new ItemActionContainer[defaultActions.Length];
            for (int i = 0; i < defaultActions.Length; i++)
            {
                currentActions[i] = new ItemActionContainer();
                currentActions[i].animName = defaultActions[i].animName;
                currentActions[i].attackInput = defaultActions[i].attackInput;
                currentActions[i].itemActual = defaultActions[i].itemActual;
                currentActions[i].weaponHook = defaultActions[i].weaponHook;

            }
        }

        public void PlayTargetAnimation(string targetAnim, bool isInteracting)
        {
            anim.SetBool("isInteracting", isInteracting);
            anim.CrossFade(targetAnim, 0.2f);
            this.isInteracting = isInteracting;
        }

        public void PlayTargetItemAction(AttackInputs attackInput)
        {
            currentAction = GetItemActionContainer(attackInput, currentActions);

            if (!string.IsNullOrEmpty(currentAction.animName))
            {
                PlayTargetAnimation(currentAction.animName, true);
            }
        }

        protected ItemActionContainer GetItemActionContainer(AttackInputs ai, ItemActionContainer[] l)
        {
            if (l == null)
                return null;

            for (int i = 0; i < l.Length; i++)
            {
                if (l[i].attackInput == ai)
                {
                    return l[i];
                }
            }
            return null;
        }

        public void LoadWeapon(Item item, bool isLeft)
        {
            WeaponItem weaponItem = null;
            if (item is WeaponItem)
            {
                weaponItem = (WeaponItem)item;
            }
            WeaponHook weaponHook = _inventoryManager.LoadWeaponOnHook(weaponItem, isLeft);

            if (weaponItem == null)
            {
                ItemActionContainer da = GetItemActionContainer(GetAttackInput(AttackInputs.rb, isLeft), defaultActions);
                ItemActionContainer ta = GetItemActionContainer(GetAttackInput(AttackInputs.rt, isLeft), currentActions);
                CopyItemActionContainer(da, ta);
                ta.weaponHook = weaponHook;
                return;
            }


            for (int i = 0; i < weaponItem.itemActions.Length; i++)
            {
                ItemActionContainer wa = weaponItem.itemActions[i];
                ItemActionContainer ic = GetItemActionContainer(GetAttackInput(wa.attackInput, isLeft), currentActions);
                CopyItemActionContainer(wa, ic);
                ic.weaponHook = weaponHook;
            }

        }

        void CopyItemActionContainer(ItemActionContainer from, ItemActionContainer to)
        {
            to.animName = from.animName;
            to.itemActual = from.itemActual;

        }

        AttackInputs GetAttackInput(AttackInputs inp, bool isLeft)
        {
            if (!isLeft)
            {
                return inp;
            }
            else
            {
                switch (inp)
                {
                    case AttackInputs.rb:
                        return AttackInputs.lb;
                    case AttackInputs.lb:
                        return AttackInputs.rb;
                    case AttackInputs.rt:
                        return AttackInputs.lt;
                    case AttackInputs.lt:
                        return AttackInputs.rt;
                    case AttackInputs.none:
                    default:
                        return inp;
                }
            }
        }

        public ActionContainer GetActionContainer()
        {
            return lastAction;
        }

        public void OnInteractAnimation(string anim)
        {
            PlayTargetAnimation(anim, true);
            isInteracting = true;
        }

        public Transform getTransform()
        {
            return mTransform;
        }
        #endregion
    }
}

