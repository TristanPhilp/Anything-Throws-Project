using UnityEngine;
using UnityEngine.Events;

public class TrebuchetController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    //rigid body throwable class.
    public bool isPlayerHere = false;
    public Rigidbody weight;
    public Rigidbody arm;
    public GameObject Throwable;
    public GameObject Player;
    Vector3 originalPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerHere == true)
        {
            weight.isKinematic = false;
            arm.isKinematic = false;
        }

        if (Input.GetKeyUp(KeyCode.Space) && isPlayerHere == true)
        {
            HingeJoint hingeToDestroy;
            hingeToDestroy = Throwable.GetComponent<HingeJoint>();

            Destroy(hingeToDestroy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerHere = false;
            weight.position = new Vector3(-10, 4f, 1.75f);
            weight.transform.Rotate(0,0,0);
            arm.transform.Rotate(-30.0f, 0.0f, 0.0f);
            arm.position = new Vector3(-10, 0.1f, 0);
            weight.isKinematic = true;
            arm.isKinematic = true;
        }
    }
}
