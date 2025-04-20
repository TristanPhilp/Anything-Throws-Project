using Unity.VisualScripting;
using UnityEngine;

public class ThrowableLoadingZone : MonoBehaviour
{
    public GameObject throwable;
    public GameObject launcher;
    [SerializeField] private Vector3 setPosition;
    public bool isThrowable = false;
    TrebuchetController trebuchetController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trebuchetController = launcher.GetComponent<TrebuchetController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //if something touches the loading zone, checks if throwable and if true makes it the current throwable.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with something");
        if (other.gameObject.TryGetComponent<Interactable>(out Interactable interact) && trebuchetController.launchable == null)
        {
            Debug.Log("Throwable detected");
            throwable = other.gameObject;
            throwable.layer = LayerMask.NameToLayer("Ignore Raycast");
            trebuchetController.launchable = throwable;
            throwable.transform.position = transform.position;
            throwable.GetComponent<Rigidbody>().isKinematic = true;
            throwable.transform.SetParent(transform);
        }

    }

    private void OnTriggerExit(Collider other)
    {

    }

}   
