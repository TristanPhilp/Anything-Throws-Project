using UnityEngine;
using UnityEngine.Events;

public class PlayerTrebuchet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    public bool isPlayerHere = false;
    public Rigidbody weight;
    public GameObject Throwable;
    public GameObject Player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerHere == true)
        {
            weight.isKinematic = false;
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
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
