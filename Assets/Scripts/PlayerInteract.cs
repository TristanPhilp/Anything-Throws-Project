using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerController))]
public class PlayerInteract : MonoBehaviour
{
    InputAction interactAction;
    Camera playerCam;

    public float interactDistance;
    GameObject seenObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        playerCam = GetComponent<PlayerController>().playerCam;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactAction.WasPressedThisFrame())
        {
            if (seenObject != null && seenObject.TryGetComponent<Interactable>(out Interactable interactable))
            {
                //OBJECT INTERACTION CODE HERE
                interactable.OnInteract();
            }
        }

        RaycastHit hit;

        Vector3 forward = playerCam.transform.TransformDirection(Vector3.forward) * interactDistance;
        Ray ray = new Ray(playerCam.transform.position, forward);
        Debug.DrawRay(playerCam.transform.position, forward, Color.red);
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.gameObject != seenObject)
            {
                seenObject = hit.collider.gameObject;
                if (hit.collider.gameObject.TryGetComponent<Interactable>(out Interactable interact))
                {
                    Debug.Log("Looking At Interactable");
                    interact.OnHover();
                }
                else
                {
                    Debug.Log("Looking At Something");
                }
            }


        }
        else
        {
            seenObject = null;
        }
    }
}
