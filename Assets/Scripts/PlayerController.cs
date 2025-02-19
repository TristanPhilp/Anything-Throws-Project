using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public Camera playerCam;
    public float sensitivity;
    public float moveSpeed;


    public float interactDistance;
    bool throwableSeen;
    GameObject seenObject;

    InputAction lookAction;
    InputAction moveAction;
    InputAction interactAction;
    float horizontalInput;
    float verticalInput;
    Vector3 moveValue;

    Rigidbody m_Rigidbody;

    //trash variable for figuring out the camera raycast
    Vector3 pos;

    //float maxLook;
    //float minLook;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //defines how far up and down the player can look
        //currently unused.
        //maxLook = 90;
        //minLook = -90;

        pos = new Vector3(200, 200, 0);

        lookAction = InputSystem.actions.FindAction("Look");
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
        m_Rigidbody = GetComponent<Rigidbody>();

        throwableSeen = false;
        

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Takes the horizontal movement of the current pointer device and rotates the entire player object
        horizontalInput = lookAction.ReadValue<Vector2>().x;
        Quaternion deltaRotation = Quaternion.Euler(0, horizontalInput * sensitivity * Time.fixedDeltaTime, 0);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);

        //Same thing, but for vertical
        //Tried getting the camera to limit vertical movement, but couldn't figure it out after 2 hours so I gave up.
        verticalInput = -lookAction.ReadValue<Vector2>().y;
        Vector3 deltaVert = new Vector3(verticalInput * sensitivity * Time.fixedDeltaTime, 0, 0);
        playerCam.transform.Rotate(deltaVert);

        //Movement code. Jank af but I've been at this for 5 hours and no longer care.
        moveValue.x = moveAction.ReadValue<Vector2>().x;
        moveValue.z = moveAction.ReadValue<Vector2>().y;
        m_Rigidbody.MovePosition(transform.position + (transform.forward * moveValue.z * moveSpeed * Time.fixedDeltaTime) + (transform.right * moveValue.x * moveSpeed * Time.fixedDeltaTime));

        if (interactAction.IsPressed() && throwableSeen == true)
        {
            //OBJECT INTERACTION CODE HERE
            seenObject.GetComponent<ThrowableClass>().Select();
        }
    }

    void Update()
    {
        //This area for object highlighting


        //Handles the checking for whether there's an object in front of 
        RaycastHit hit;

        Vector3 forward = playerCam.transform.TransformDirection(Vector3.forward) * interactDistance;
        Ray ray = new Ray(playerCam.transform.position, forward);
        Debug.DrawRay(playerCam.transform.position, forward, Color.red);
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            seenObject = hit.collider.gameObject;
            //Transform objectHit = hit.transform;
            
            if (hit.collider.gameObject.TryGetComponent<ThrowableClass>(out ThrowableClass throwable))
            {
                throwableSeen = true;
                Debug.Log("Looking At Throwable");
            }
            else
            {
                Debug.Log("Looking At Something");
                throwableSeen = false;
            }
        }
        else
        {
            throwableSeen = false;
        }
    }
}
