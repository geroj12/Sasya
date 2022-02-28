// GENERATED AUTOMATICALLY FROM 'Assets/Game/Data/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""bf3de676-94fe-4fc7-b743-7f269fe30908"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ecdc4106-33d5-40f2-a11c-9912d078c7db"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6f0e2210-cb5e-4db7-b352-d6a591beb749"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RB"",
                    ""type"": ""Button"",
                    ""id"": ""73da331b-c010-4695-9956-12fb9e9d98c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LB"",
                    ""type"": ""Button"",
                    ""id"": ""6aa429ac-70bf-41d3-b503-e4c8b63bce51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LT"",
                    ""type"": ""Button"",
                    ""id"": ""70a0bffd-4db3-453c-a8f0-9e12cddc1bcd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RT"",
                    ""type"": ""Button"",
                    ""id"": ""654bfa68-8c55-4aa5-96eb-31f61336dcfe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lock"",
                    ""type"": ""Button"",
                    ""id"": ""357d4faf-5ec6-426d-bf03-700d8f0a7981"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""92976156-ecb4-4537-9a9e-964055f16bd2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""ae556222-44e1-424b-8e1e-63e7635c0893"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Consume"",
                    ""type"": ""Button"",
                    ""id"": ""70c2f63e-ddfa-442d-b89e-87d40f5e4060"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D_Up"",
                    ""type"": ""Button"",
                    ""id"": ""fec77032-2fd1-484c-b1b8-b151fd921d5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D_Left"",
                    ""type"": ""Button"",
                    ""id"": ""7593687e-ca52-4382-a55a-31b3849ba8e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D_Right"",
                    ""type"": ""Button"",
                    ""id"": ""c9a78a88-b2b9-4656-ba2a-48291b18a9d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D_Down"",
                    ""type"": ""Button"",
                    ""id"": ""2f920b31-0f39-4242-8e9b-a67e4af4d1b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""319bfee6-0123-4ba2-bdda-3574f6256487"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""e95d286b-5138-41bf-bc52-84ee2a4ea0c1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5dc95951-9e59-4d4a-9748-9d668e1d2f17"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6a7916a8-26b2-40e7-a9cf-3fd15d258add"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""03b74fcd-a3e3-4fd9-960a-368817836f5d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8494d01b-68ab-4780-9911-bca58496d287"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cfa59104-1e5e-4d2e-b1e1-ecce6c5360c7"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02ac2d3c-37ab-49e6-9d08-35df06c1e23d"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bb96aa1-fbf7-4020-9834-48ae9096c6bc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""920ba03a-f43d-4fed-8b6b-889ceb06959c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9785aaea-6496-42be-9615-7f31e564443d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51ec2743-868f-40dc-82ae-975b05f8625e"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b721290d-7c35-4233-b9f1-ce7492417bf1"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9156db01-33a5-4510-8bfd-e828869420bd"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aaa2f79f-ca3d-4b0b-ae11-547667e9867d"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a085d6a-ceb4-47a3-b15f-58e953506663"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f338ab1-e76b-4674-a781-986ca4925078"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0437aee8-9462-465a-827a-f68c04da07f8"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Consume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46612b29-99c5-412c-be87-ff3e0a78783c"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D_Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""238f22d1-1364-4c65-b15f-36155e95c62e"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9685c1ea-476b-4330-a7d8-e3d6d09bca76"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d374c66-34bb-4299-8316-24da1b03821b"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D_Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1daef53c-a026-4149-a163-04ff59ae9f2f"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""79928c30-7e63-4fc6-9165-6425eedf25d1"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""46ddb36c-b7fa-4ca3-823a-e2faed0ee030"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""892b894e-4375-4f89-b8a1-10c01a1b0a64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""escape"",
                    ""type"": ""Button"",
                    ""id"": ""a9322449-01b0-431b-aa30-e662d141ddd2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AnyKey"",
                    ""type"": ""Button"",
                    ""id"": ""9c2a0dba-e699-4d60-ab7b-ab0b2533294f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ad9e4ad3-c996-4ece-aae8-1b1100c3f7d2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76ff1685-7f89-4fdc-9931-2495fd6e3bf8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9dc435a-a800-4935-9933-a74002819fe2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14909439-4d1c-40fc-8515-9f7f650110e9"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Camera = m_Player.FindAction("Camera", throwIfNotFound: true);
        m_Player_RB = m_Player.FindAction("RB", throwIfNotFound: true);
        m_Player_LB = m_Player.FindAction("LB", throwIfNotFound: true);
        m_Player_LT = m_Player.FindAction("LT", throwIfNotFound: true);
        m_Player_RT = m_Player.FindAction("RT", throwIfNotFound: true);
        m_Player_Lock = m_Player.FindAction("Lock", throwIfNotFound: true);
        m_Player_Roll = m_Player.FindAction("Roll", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Consume = m_Player.FindAction("Consume", throwIfNotFound: true);
        m_Player_D_Up = m_Player.FindAction("D_Up", throwIfNotFound: true);
        m_Player_D_Left = m_Player.FindAction("D_Left", throwIfNotFound: true);
        m_Player_D_Right = m_Player.FindAction("D_Right", throwIfNotFound: true);
        m_Player_D_Down = m_Player.FindAction("D_Down", throwIfNotFound: true);
        m_Player_MousePosition = m_Player.FindAction("MousePosition", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_escape = m_UI.FindAction("escape", throwIfNotFound: true);
        m_UI_AnyKey = m_UI.FindAction("AnyKey", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Camera;
    private readonly InputAction m_Player_RB;
    private readonly InputAction m_Player_LB;
    private readonly InputAction m_Player_LT;
    private readonly InputAction m_Player_RT;
    private readonly InputAction m_Player_Lock;
    private readonly InputAction m_Player_Roll;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Consume;
    private readonly InputAction m_Player_D_Up;
    private readonly InputAction m_Player_D_Left;
    private readonly InputAction m_Player_D_Right;
    private readonly InputAction m_Player_D_Down;
    private readonly InputAction m_Player_MousePosition;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Camera => m_Wrapper.m_Player_Camera;
        public InputAction @RB => m_Wrapper.m_Player_RB;
        public InputAction @LB => m_Wrapper.m_Player_LB;
        public InputAction @LT => m_Wrapper.m_Player_LT;
        public InputAction @RT => m_Wrapper.m_Player_RT;
        public InputAction @Lock => m_Wrapper.m_Player_Lock;
        public InputAction @Roll => m_Wrapper.m_Player_Roll;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Consume => m_Wrapper.m_Player_Consume;
        public InputAction @D_Up => m_Wrapper.m_Player_D_Up;
        public InputAction @D_Left => m_Wrapper.m_Player_D_Left;
        public InputAction @D_Right => m_Wrapper.m_Player_D_Right;
        public InputAction @D_Down => m_Wrapper.m_Player_D_Down;
        public InputAction @MousePosition => m_Wrapper.m_Player_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @RB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRB;
                @RB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRB;
                @RB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRB;
                @LB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLB;
                @LB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLB;
                @LB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLB;
                @LT.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLT;
                @LT.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLT;
                @LT.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLT;
                @RT.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRT;
                @RT.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRT;
                @RT.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRT;
                @Lock.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLock;
                @Lock.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLock;
                @Lock.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLock;
                @Roll.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRoll;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Consume.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnConsume;
                @Consume.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnConsume;
                @Consume.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnConsume;
                @D_Up.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Up;
                @D_Up.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Up;
                @D_Up.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Up;
                @D_Left.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Left;
                @D_Left.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Left;
                @D_Left.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Left;
                @D_Right.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Right;
                @D_Right.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Right;
                @D_Right.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Right;
                @D_Down.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Down;
                @D_Down.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Down;
                @D_Down.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD_Down;
                @MousePosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @RB.started += instance.OnRB;
                @RB.performed += instance.OnRB;
                @RB.canceled += instance.OnRB;
                @LB.started += instance.OnLB;
                @LB.performed += instance.OnLB;
                @LB.canceled += instance.OnLB;
                @LT.started += instance.OnLT;
                @LT.performed += instance.OnLT;
                @LT.canceled += instance.OnLT;
                @RT.started += instance.OnRT;
                @RT.performed += instance.OnRT;
                @RT.canceled += instance.OnRT;
                @Lock.started += instance.OnLock;
                @Lock.performed += instance.OnLock;
                @Lock.canceled += instance.OnLock;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Consume.started += instance.OnConsume;
                @Consume.performed += instance.OnConsume;
                @Consume.canceled += instance.OnConsume;
                @D_Up.started += instance.OnD_Up;
                @D_Up.performed += instance.OnD_Up;
                @D_Up.canceled += instance.OnD_Up;
                @D_Left.started += instance.OnD_Left;
                @D_Left.performed += instance.OnD_Left;
                @D_Left.canceled += instance.OnD_Left;
                @D_Right.started += instance.OnD_Right;
                @D_Right.performed += instance.OnD_Right;
                @D_Right.canceled += instance.OnD_Right;
                @D_Down.started += instance.OnD_Down;
                @D_Down.performed += instance.OnD_Down;
                @D_Down.canceled += instance.OnD_Down;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_escape;
    private readonly InputAction m_UI_AnyKey;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @escape => m_Wrapper.m_UI_escape;
        public InputAction @AnyKey => m_Wrapper.m_UI_AnyKey;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @escape.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
                @escape.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
                @escape.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEscape;
                @AnyKey.started -= m_Wrapper.m_UIActionsCallbackInterface.OnAnyKey;
                @AnyKey.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnAnyKey;
                @AnyKey.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnAnyKey;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @escape.started += instance.OnEscape;
                @escape.performed += instance.OnEscape;
                @escape.canceled += instance.OnEscape;
                @AnyKey.started += instance.OnAnyKey;
                @AnyKey.performed += instance.OnAnyKey;
                @AnyKey.canceled += instance.OnAnyKey;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnRB(InputAction.CallbackContext context);
        void OnLB(InputAction.CallbackContext context);
        void OnLT(InputAction.CallbackContext context);
        void OnRT(InputAction.CallbackContext context);
        void OnLock(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnConsume(InputAction.CallbackContext context);
        void OnD_Up(InputAction.CallbackContext context);
        void OnD_Left(InputAction.CallbackContext context);
        void OnD_Right(InputAction.CallbackContext context);
        void OnD_Down(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnAnyKey(InputAction.CallbackContext context);
    }
}
