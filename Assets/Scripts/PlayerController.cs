using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public Camera playerCam;
    public float sensitivity;
    public float moveSpeed;


    InputAction lookAction;
    InputAction moveAction;
    InputAction interactAction;

    float horizontalInput;
    float verticalInput;
    Vector3 moveValue;

    Rigidbody m_Rigidbody;

    Pointer pointer;

    //float maxLook;
    //float minLook;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //defines how far up and down the player can look
        //currently unused.
        //maxLook = 90;
        //minLook = -90;

        lookAction = InputSystem.actions.FindAction("Look");
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
        pointer = Pointer.current;
        m_Rigidbody = GetComponent<Rigidbody>();


        //locks the cursor to the center of the screen and hides it
        //Why Unity hasn't made this the default, I don't know
        
    }
    //poopfart
    // Update is called once per frame
    void Update()
    {
        //Takes the horizontal movement of the current pointer device and rotates the entire player object
        horizontalInput = lookAction.ReadValue<Vector2>().x;
        Quaternion deltaRotation = Quaternion.Euler(0, horizontalInput * sensitivity * Time.deltaTime, 0);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);

        //Same thing, but for vertical
        //Tried getting the camera to limit vertical movement, but couldn't figure it out after 2 hours so I gave up.
        verticalInput = -lookAction.ReadValue<Vector2>().y;
        Vector3 deltaVert = new Vector3(verticalInput * sensitivity * Time.deltaTime, 0, 0);
        playerCam.transform.Rotate(deltaVert);

        //Movement code. Jank af but I've been at this for 5 hours and no longer care.
        moveValue.x = moveAction.ReadValue<Vector2>().x;
        moveValue.z = moveAction.ReadValue<Vector2>().y;
        m_Rigidbody.MovePosition(transform.position + (transform.forward * moveValue.z * moveSpeed * Time.deltaTime) + (transform.right * moveValue.x * moveSpeed * Time.deltaTime));

        if (interactAction.IsPressed())
        {
            //OBJECT INTERACTION CODE HERE
        }
    }


}
