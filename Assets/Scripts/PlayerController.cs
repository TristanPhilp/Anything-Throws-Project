using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using System;


public class PlayerController : MonoBehaviour
{
    public Camera playerCam;
    [SerializeField]public float horizSensitivity;
    [SerializeField]public float vertSensitivity;

    public float moveSpeed;
    public float x_rot = 0.0f;


    

    InputAction lookAction;
    InputAction moveAction;
    float horizontalInput;
    float verticalInput;
    Vector3 moveValue;

    Rigidbody m_Rigidbody;

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
        m_Rigidbody = GetComponent<Rigidbody>();
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

        //Movement code. Jank af but I've been at this for 5 hours and no longer care.
        moveValue.x = moveAction.ReadValue<Vector2>().x;
        moveValue.z = moveAction.ReadValue<Vector2>().y;
        m_Rigidbody.MovePosition(transform.position + (transform.forward * moveValue.z * moveSpeed * Time.fixedDeltaTime) + (transform.right * moveValue.x * moveSpeed * Time.fixedDeltaTime));

        
    }

	void Update()
	{
		//Takes the horizontal movement of the current pointer device and rotates the entire player object
		horizontalInput = lookAction.ReadValue<Vector2>().x;
		verticalInput = lookAction.ReadValue<Vector2>().y;


		//Body rotation code.
		Quaternion deltaRotation = Quaternion.Euler(0, horizontalInput * horizSensitivity * Time.deltaTime, 0);
		m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
		
		//Concocting the view angles.
		float viewX = horizontalInput * horizSensitivity * Time.deltaTime; 
		float viewY = verticalInput * vertSensitivity * Time.deltaTime;

		
		x_rot -= viewY;
		x_rot = Mathf.Clamp(x_rot, -70f, 70f); //Limiter, -70f is the lowest y-rot and 70f is highest y-rot.

		playerCam.transform.localRotation = Quaternion.Euler(x_rot, 0f, 0f); //camera rotation!


	}
}
