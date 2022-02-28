using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Purgatory
{
    public class PlayerStateManager : CharacterStateManager
    {
        [Header("Inputs")]
        public float mouseX;
        public float mouseY;
        public float moveAmount;
        public Vector3 rotateDirection;
        public Vector3 rollDirection;

        [HideInInspector]
        public string locomotionId = "locomotion";
        [HideInInspector]
        public string attackStateId = "attackId";
        [HideInInspector]
        public string rollStateId = "waitState";

        [Header("Movement Stats")]
        public float frontRayOffset = .5f;
        public float movementSpeed = 2;
        public float rollSpeed = 1;
        public float adaptSpeed = 10;
        public float rotationSpeed = 10;
        public float attackRotationSpeed = 3;
        public float navMeshDetectDistance = 1;
        public bool isRolling;
        public AnimationCurve rollCurve;
        public AnimationClip rollClip; 


        [Header("References")]
        public new Transform camera;
        //public Cinemachine.CinemachineFreeLook normalCamera;
        //public Cinemachine.CinemachineFreeLook lockOnCamera;


        [HideInInspector]
        public LayerMask ignoreForGroundcheck;


        public override void Init()
        {
            base.Init();


            //can be populated in many actions
            State locomotion = new State(
                new List<StateAction>()  //Fixed Update
                {
                    //movePlayerCharacter

                },
                new List<StateAction>()  //Update
                {
                    
                },
                new List<StateAction>() //Late Update
                {

                }
                ); ;

            locomotion.onEnter = DisableRootMotion;
            //locomotion.onEnter += DisableCombo;

            MonitorInteractingAnimation monitorInteractingAnimation = new MonitorInteractingAnimation(this, "isInteracting", locomotionId);

            State attackState = new State(
                new List<StateAction>()  //Fixed Update
                {     
                    // new HandleRotationHook(this,movePlayerCharacter)
                },
                new List<StateAction>()  //Update
                {
                    monitorInteractingAnimation,
                    new InputsForCombo(this),                   
                },
                new List<StateAction>() //Late Update
                {

                }
                );

            attackState.onEnter = EnableRootMotion;
            attackState.onEnter += DisableComboVariables;


            State rollState = new State(
                new List<StateAction>()  //Fixed Update
                {
                     new HandleRollVelocity(this)
                },
                new List<StateAction>()  //Update
                {
                    monitorInteractingAnimation,
     
                },
                new List<StateAction>() //Late Update
                {

                }
                );

            RegisterState(locomotionId, locomotion);
            RegisterState(attackStateId, attackState);
            RegisterState(rollStateId, rollState);

            //Starting state
            ChangeState(locomotionId);

            ignoreForGroundcheck = ~(1 << 9 | 1 << 10);

            //weaponHolderManager.Init();
            weaponHolderManager.LoadWeaponOnHook(leftWeapon,true);
            weaponHolderManager.LoadWeaponOnHook(rightWeapon, false);
            UpdateItemActionsWithCurrent();
        }

        private void FixedUpdate()
        {
            delta = Time.fixedDeltaTime;
            base.FixedTick(); //will jump in StateManager and call FixedTick
        }

        public bool debugLock;

        private void Update()
        {      
            delta = Time.deltaTime;
            base.Tick(); //will jump in StateManager and call Tick
        }

        private void LateUpdate()
        {
            base.LateTick(); //will jump in StateManager and call LateTick
        }

        #region Lock on
        public override void OnAssignLookOverride(Transform target)
        {
            base.OnAssignLookOverride(target);
            if (lockOn == false)
            {
                return;
            }
            //normalCamera.gameObject.SetActive(false);
            //lockOnCamera.gameObject.SetActive(true);
            //lockOnCamera.m_LookAt = target;
        }

        public override void OnClearLookOverride()
        {
            base.OnClearLookOverride();
            //normalCamera.gameObject.SetActive(true);
            //lockOnCamera.gameObject.SetActive(false);
           
        }

        #endregion

        public override bool PlayTargetItemAction(AttackInputs attackInput)
        {
            canRotate = false;

            ItemActionContainer iac = GetItemActionContainer(attackInput, itemActions);

            if (!string.IsNullOrEmpty(iac.animName))
            {
                //iac.ExecuteItemAction(this);
                return true;
            }
            else
            {
                return false;
            }           
        }    

        #region State Events
        void DisableRootMotion()
        {
            useRootMotion = false;
            canMove = false;
        }

        void EnableRootMotion()
        {
            useRootMotion = true;
        }

        void DisableComboVariables()
        {
           // canDoCombo = false;
        }
        #endregion
    }

}
