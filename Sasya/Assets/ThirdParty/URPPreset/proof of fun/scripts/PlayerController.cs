using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerControls keys;
    Vector3 moveDirection;
    Vector3 cameraDirection;
     float vertical;
    float horizontal;
    bool leftMouse, rightMouse;
    public float moveSpeed;
    public float health;
    public float maxhealth;
    private Rigidbody rb;

    public Animator anim;
    public Animator canvasAnim;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    [SerializeField]
    public Weapon standardfire;
    public Weapon blast;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();

        keys = new PlayerControls();
        keys.Player.Movement.performed += i => moveDirection = i.ReadValue<Vector2>();
        keys.Player.Camera.performed += i => cameraDirection = i.ReadValue<Vector2>();
        keys.Enable();
    }
   
    void HandleInput()
    {
        vertical = moveDirection.y;
        horizontal = moveDirection.x;

        leftMouse = GetButtonStatus(keys.Player.RB.phase);
        rightMouse = GetButtonStatus(keys.Player.RT.phase);
    }

    bool GetButtonStatus(UnityEngine.InputSystem.InputActionPhase phase)
    {
        return phase == UnityEngine.InputSystem.InputActionPhase.Started;
    }

    void HandleMovement(float delta)
    {
        moveInput = new Vector3(horizontal, 0, vertical);
        moveVelocity = moveInput * moveSpeed;
        Ray cameraRay = mainCamera.ScreenPointToRay(cameraDirection);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            //Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            //this.transform.Rotate(new Vector3(0f, cameraDirection.x, 0f), Space.World);
        }
    }

    void Update()
    {      
        HandleInput();

        if (leftMouse)
        {
            standardfire.isFiring = true;
        }
        else
        {
            standardfire.isFiring = false;
        }


        if (rightMouse)
        {
            blast.isFiring = true;
            anim.SetTrigger("shot");

        }
        else
        {
            blast.isFiring = false;

        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;

        float delta = Time.fixedDeltaTime;
        HandleMovement(delta);

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy_Bullet" || collision.gameObject.tag == "Enemy_Bullet_ND") {
            health--;
            canvasAnim.SetTrigger("damage");
            Destroy(collision.gameObject);
        }
    }
   }
