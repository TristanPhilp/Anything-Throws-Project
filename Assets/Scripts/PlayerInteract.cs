using UnityEngine;
using UnityEngine.InputSystem;


//[RequireComponent(typeof(PlayerController))]
public class PlayerInteract : MonoBehaviour
{
    InputAction interactAction;
    public GameObject guidePoint;
    Joint guideHinge;

    public float interactDistance;
    GameObject seenObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        guidePoint.transform.localPosition = new Vector3(0, 0, interactDistance);
        guideHinge = guidePoint.GetComponent<Joint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactAction.WasPressedThisFrame())
        {
            if (seenObject != null && seenObject.TryGetComponent<Interactable>(out Interactable interactable))
            {
                //OBJECT INTERACTION CODE HERE
                if (interactable.OnInteract() == 1 && guideHinge.connectedBody == null)
                {
                    guideHinge.connectedBody = interactable.gameObject.GetComponent<Rigidbody>();
                }
                else if (interactable.OnInteract() == 1 && guideHinge.connectedBody != null)
                {
                    guideHinge.connectedBody = null;
                }
            }
        }

        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * interactDistance;
        Ray ray = new Ray(transform.position, forward);
        Debug.DrawRay(transform.position, forward, Color.red);
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.gameObject != seenObject)
            {
                seenObject = hit.collider.gameObject;
                if (seenObject.TryGetComponent<Interactable>(out Interactable interact))
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
        else if (seenObject != null)
        {
            if (seenObject.TryGetComponent<Interactable>(out Interactable interact))
            {
                Debug.Log("Looked away from Interactable");
                interact.OffHover();
            }
            seenObject = null;
        }
    }
}
