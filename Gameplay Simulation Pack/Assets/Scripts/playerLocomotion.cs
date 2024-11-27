using UnityEngine;
using UnityEngine.EventSystems;

public class playerLocomotion : MonoBehaviour
{
    

    // Private
    Vector3 moveDirection;
    Transform cameraObject;


    // Public



    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    public void HandleMovement()
    {
        moveDirection = cameraObject.forward; // Movement Input

    }
}
