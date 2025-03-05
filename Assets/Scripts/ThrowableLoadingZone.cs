using Unity.VisualScripting;
using UnityEngine;

public class ThrowableLoadingZone : MonoBehaviour
{
    public Rigidbody Throwable;
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
