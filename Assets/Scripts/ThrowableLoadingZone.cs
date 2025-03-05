using Unity.VisualScripting;
using UnityEngine;

public class ThrowableLoadingZone : MonoBehaviour
{
    public GameObject throwable;
    public GameObject launcher;
    [SerializeField] private Vector3 setPosition;
    public bool isThrowable = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    //if something touches the loading zone, checks if throwable and if true makes it the current throwable.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with something");
        if (other.CompareTag("Throwable"))
        {
            Debug.Log("Throwable detected");
            throwable = other.gameObject;
            launcher.GetComponent<TrebuchetController>().launchable = throwable;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Throwable"))
        {
            throwable = null;
        }

    }

}   
