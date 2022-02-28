using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Purgatory
{
    public class InputManager :  MonoBehaviour
    {
        public CameraManager cameraManager;
        public Player controller;
        public Transform camTransform;
        public GameUI ui;
        [SerializeField]
        private GameObject cutScene;
        //Triggers
        bool Rb, Rt, Lb, Lt, b_Input, y_Input, x_Input, isAttacking,escape;

        float vertical;
        float horizontal;
        float moveAmount;
        float mouseX;
        float mouseY;
        bool rollFlag;
        float rollTimer;
        
        Vector2 moveDirection;
        Vector2 cameraDirection;
        PlayerControls keys;

        public PlayerProfile playerProfile;     

        public ExecutionOrder cameraMovement;
        public enum ExecutionOrder
        {
            fixedUpdate, update, lateUpdate
        }

        private void Start()
        {
            //check if you have a controller assigned and if not, instantiate
            camTransform = Camera.main.transform;

            controller.Init();
            controller.InitInventory(playerProfile);
            
            cameraManager.targetTransform = controller.transform;

            keys = new PlayerControls();
            keys.Player.Movement.performed += i => moveDirection = i.ReadValue<Vector2>(); //whenever the key is down of inputs, will run a method which creates by a delegate
            keys.Player.Camera.performed += i => cameraDirection = i.ReadValue<Vector2>();
            keys.UI.Click.performed += i =>
            keys.UI.AnyKey.canceled += i => ui.AnyKeyPressed();
            keys.Player.D_Left.performed += i => HandleSwitchWeapons(true);
            keys.Player.D_Right.performed += i => HandleSwitchWeapons(false);           
            keys.Enable();

            Settings.interactionsLayer = ~(1 << 15);

        }

        private void OnDisable()
        {
            keys.Disable();
        }

        private void FixedUpdate()
        {
            if (controller == null)
                return;

            float delta = Time.fixedDeltaTime;

            HandleMovement(delta);
            //Debug.Log("handle movement");
            cameraManager.FollowTarget(delta);       
        }
        Vector3 lookPos;
        private void Update()
        {
            if (controller == null)
                return;

            float delta = Time.deltaTime;

            HandleInput();

            if (b_Input)
            {
                rollFlag = true;
                rollTimer += delta;
            }

            if (cameraMovement == ExecutionOrder.update)
            {
                //cameraManager.HandleRotation(delta, mouseX, mouseY);
            }
           



            }
        

        private void LateUpdate()
        {
          
            if (escape)
            {
                PauseButton();
            }
        }

        void HandleSwitchWeapons(bool isLeft)
        {
            if (controller.isInteracting)
                return;

            controller.inventoryManager.SwitchWeapon(isLeft);
        }

        void HandleMovement(float delta)
        {
            controller.MoveCharacter(vertical, horizontal);
        }

        bool GetButtonStatus(UnityEngine.InputSystem.InputActionPhase phase)
        {
            return phase == UnityEngine.InputSystem.InputActionPhase.Started;
        }

        void HandleInput()
        {
            bool retVal = false;
            isAttacking = false;

            vertical = moveDirection.y;
            horizontal = moveDirection.x;
            mouseX = cameraDirection.x;
            mouseY = cameraDirection.y;

            Rb = GetButtonStatus(keys.Player.RB.phase);
            Rt = GetButtonStatus(keys.Player.RT.phase);
            Lb = GetButtonStatus(keys.Player.LB.phase);
            Lt = GetButtonStatus(keys.Player.LT.phase);
            b_Input = GetButtonStatus(keys.Player.Roll.phase);
            x_Input = GetButtonStatus(keys.Player.Consume.phase);
            escape = GetButtonStatus(keys.UI.escape.phase);
            moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));



            if (retVal == false)
                retVal = HandleAttacking();   




        }

       
       
        bool HandleAttacking()
        {
            AttackInputs attackInput = AttackInputs.none;

            if (Rb || Rt || Lb || Lt)
            {
                isAttacking = true;

                if (Rb)
                {
                    attackInput = AttackInputs.rb;
                }
                if (Rt)
                {
                    attackInput = AttackInputs.rt;
                }
                if (Lb)
                {
                    attackInput = AttackInputs.lb;
                }
                if (Lt)
                {
                    attackInput = AttackInputs.lt;
                }
            }

            if (y_Input)
            {

            }

            if (attackInput != AttackInputs.none)
            {
                if (!controller.isInteracting)
                {

                    controller.PlayTargetItemAction(attackInput);
                }             
            }
            return isAttacking;
        }

      

        public GameObject PauseGamePanel;
        public void PauseButton()
        {
            Time.timeScale = 0;
            PauseGamePanel.SetActive(true);
            cutScene.SetActive(false);
        }

        public void ResumeButton()
        {
            Time.timeScale = 1;
            PauseGamePanel.SetActive(false);
            

        }
        public void MainMenu()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
        public void ExitButton()
        {
            Application.Quit();

        }
        }
    }
    
    

