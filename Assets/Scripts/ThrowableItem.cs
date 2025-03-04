using Unity.VisualScripting;
using UnityEngine;

public class ThrowableItem : MonoBehaviour
{
    public Rigidbody Throwable;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Throwable"))
        {
            Throwable.position = new Vector3(0, 0, 0 );
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Throwable") && Input.GetKeyUp(KeyCode.Space))
        {

        }

    }

}   
