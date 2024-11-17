using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovements : MonoBehaviour
{
    // Private
    Vector2 direction = Vector2.zero;
    private InputAction move;
    private InputAction jump;


    // Public
    public PlayerInputActions playerControls;



    public Rigidbody rb;
    public float moveSpeed = 100f;
    public float jumpHeight = 100f;

    private void Awake()
    {
        // rb = GetComponent<Rigidbody>();
        playerControls = new PlayerInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        MovePlayer();
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
        //direction = playerControls.ReadValue<Vector2>();
        direction = move.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * moveSpeed * Time.deltaTime;
    }

    private void Jump(InputAction.CallbackContext con)
    {
        Debug.Log("Jump Pressed");
        //rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

}
