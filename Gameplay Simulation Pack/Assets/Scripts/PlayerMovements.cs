using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

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
        anim = GetComponent<Animator>();
        anim.Play("Walking"); // Replace "Walking" with the exact animation state name
    }


    // Update is called once per frame
    void Update()
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
        // Get movement direction
        direction = move.ReadValue<Vector2>();

        // Calculate movement
        Vector3 movement = new Vector3(direction.x, 0, direction.y) * moveSpeed * Time.deltaTime;

        // Move the player
        transform.position += movement;

        // Rotate the player to face movement direction
        if (direction != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Play walking animation
            Debug.Log("Player is moving");
            isWalking = true;
        }
        else
        {
            // Stop walking animation
            Debug.Log("Player is idle");
            isWalking= false;
        }
    }

    private void Jump(InputAction.CallbackContext con)
    {
        Debug.Log("Jump Pressed");
        //rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

}
