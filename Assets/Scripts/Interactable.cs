using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    [Header("Interactable Functions")] 
    public UnityEvent onHover;
    public UnityEvent onInteract;
    public Rigidbody Throwable;

    [Header("Interactable Variables")]
    [SerializeField] private Vector3 setPosition;
    public bool isThrowable = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isThrowable == true)
        {
            Throwable.position = setPosition;
        }
    }

    //These functions may not be needed, but oh well
    //All these do is allow interaction to be implemented on any object without needing to tweak the player interact code.
    public void OnHover()
    {
        onHover.Invoke();
    }
    public void OnInteract()
    {
        onInteract.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Throwable"))
        {
            isThrowable = true;
            Debug.Log("Trick");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Throwable"))
        {
            isThrowable = false;
        }

    }
}
