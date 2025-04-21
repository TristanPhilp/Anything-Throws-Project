using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Camera playerCam;
    [SerializeField]public float horizSensitivity;
    [SerializeField]public float vertSensitivity;
    [SerializeField]public PlayerInput playerInput;

    AudioSource audioPlayer;
    public AudioClip walk;
    public AudioClip run;

    public float moveSpeed;
    public float sprintModifier;
    private float controllerLookAdjust = 20.0f;

    float isSprint = 0;

    InputAction lookAction;
    InputAction moveAction;
    InputAction sprintAction;
    float horizontalInput;
    float verticalInput;
    Vector3 moveValue;
    float x_rot;

    bool playerFSPUpdated = false;
    public Vector3 playerFailSafePosition;
    public bool warped = false;
    float TPtillUltraFailSafe = 30; //If the player is getting teleported constantly before the FSP can be updated.
    //Referred to in short as playerFSP.

    Rigidbody m_Rigidbody;



    void updatePlayerFSP()
    {
        playerFailSafePosition = new Vector3(transform.position.x, 40.1f, transform.position.z);
        playerFSPUpdated = false;
        TPtillUltraFailSafe = 30;
    }
    void warpPlayer()
    {
        
        if (TPtillUltraFailSafe > 0)
        {
            
            transform.position = playerFailSafePosition;
            TPtillUltraFailSafe -= 10;
            warped = false;
        }
        if (TPtillUltraFailSafe <= 0)
        {
            playerFailSafePosition = new Vector3(195.0f, 37.0f, 152.0f);
            transform.position = new Vector3(195.0f, 37.0f, 152.0f);
            warped = false;

        }
    }

    //float maxLook;
    //float minLook;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //defines how far up and down the player can look
        //currently unused.
        //maxLook = 90;
        //minLook = -90;

        playerFailSafePosition = transform.position;

        lookAction = InputSystem.actions.FindAction("Look");
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        m_Rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        audioPlayer = GetComponent<AudioSource>();
    }

    void LateUpdate()
    {


        //Takes the horizontal movement of the current pointer device and rotates the entire player object
        horizontalInput = lookAction.ReadValue<Vector2>().x;
        verticalInput = lookAction.ReadValue<Vector2>().y;

        //if (!InputSystem.currentControlScheme.Equals("Keyboard&Mouse"))
        //{
        //    horizontalInput *= controllerLookAdjust;
        //    verticalInput *= controllerLookAdjust;
        //} //manually tweak lookspeed on controller.

        //Concocting the view angles.
        float viewX = horizontalInput * horizSensitivity * Time.deltaTime;
        float viewY = verticalInput * vertSensitivity * Time.deltaTime;

        x_rot -= viewY;
        x_rot = Mathf.Clamp(x_rot, -70f, 70f); //Limiter, -70f is the lowest y-rot and 70f is highest y-rot.

        playerCam.transform.localRotation = Quaternion.Euler(x_rot, 0f, 0f); //camera rotation!

        //Body rotation code.
        Quaternion deltaRotation = Quaternion.Euler(0, horizontalInput * horizSensitivity * Time.deltaTime, 0);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (playerFSPUpdated == false)
        {
            Invoke("updatePlayerFSP", 10f);
            playerFSPUpdated = true;
        }

        if (transform.position.y < 26)
        {
            if (warped == false)
            {
                Invoke("warpPlayer", 0.1f);
                warped = true;
            }

        }




        isSprint = sprintAction.IsPressed() ?  1 : 0;

        //Movement code. Jank af but I've been at this for 5 hours and no longer care.
        moveValue.x = moveAction.ReadValue<Vector2>().x;
        moveValue.z = moveAction.ReadValue<Vector2>().y;
        m_Rigidbody.MovePosition(transform.position + (transform.forward * moveValue.z * (moveSpeed * (1 + sprintModifier * isSprint)) * Time.fixedDeltaTime) + (transform.right * moveValue.x * (moveSpeed * (1 + sprintModifier * isSprint)) * Time.fixedDeltaTime));

    }

	void Update()
	{

        

        


        //Checks if currently moving or not
        if ((moveValue.x != 0) || (moveValue.z != 0))
        {
            if (isSprint == 1)
            {
                audioPlayer.clip = run;
                //UnityEngine.Debug.Log("Play Sprint");
            }
            else
            {
                audioPlayer.clip = walk;
                //UnityEngine.Debug.Log("Play Walk");
            }

            if (!audioPlayer.isPlaying)
            {
                audioPlayer.Play();
            }
            else
            {
                audioPlayer.UnPause();
            }
        }
        else
        {
            audioPlayer.Pause();
            //Debug.Log("Shhh");
        }

    }
}
