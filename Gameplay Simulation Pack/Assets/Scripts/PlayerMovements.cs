using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    // Private
    Vector2 direction = Vector2.zero;
    private InputAction move;
    private InputAction jump;
    bool isWalking;


    // Public
    public PlayerInputActions playerControls;



    public Rigidbody rb;
    public float moveSpeed = 100f;
    public float jumpHeight = 100f;
    public float rotationSpeed = 10f; // Adjust rotation speed here
    public Animator anim;

    private void Awake()
    {
        // rb = GetComponent<Rigidbody>();
        playerControls = new PlayerInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        // anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();


        // Animations
        anim.SetBool("Walk", isWalking);
    }

    private void OnEnable()
    {
        playerControls.Enable();
        move = playerControls.Gameplay.Move;
        

        jump = playerControls.Gameplay.Jump;
        jump.performed += Jump;
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void MovePlayer()
    {
        






    }

    private void Jump(InputAction.CallbackContext con)
    {
        Debug.Log("Jump Pressed");
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

}
