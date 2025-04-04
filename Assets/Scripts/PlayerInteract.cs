using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;


//[RequireComponent(typeof(PlayerController))]
public class PlayerInteract : MonoBehaviour
{
    InputAction interactAction;
    public GameObject guidePoint;
    Joint guideHinge;

    public float interactDistance;
    Interactable seenObject;
    private bool holding = false;
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
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * interactDistance;
        Ray ray = new Ray(transform.position, forward);
        Debug.DrawRay(transform.position, forward, Color.red);

        if (holding == false)
        {
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.gameObject != seenObject)
                {
                    if (hit.collider.gameObject.TryGetComponent<Interactable>(out Interactable interact))
                    {
                        seenObject = interact;
                        seenObject.OnHover();
                    }
                    else
                    {
                        Debug.Log("Looking At Something");
                    }
                }
            }
        }
        else if (seenObject != null)
        {
            seenObject.OffHover();
            seenObject = null;
        }

        if (interactAction.WasPressedThisFrame() && seenObject != null)
        {
            if (seenObject.OnInteract() == 1)
            {
                swtich (holding)
                {
                    case true:
                        holding = false;
                        break;
                    case false:
                        holding = true;
                        break;
                }
            }
        }

        
    }
}
