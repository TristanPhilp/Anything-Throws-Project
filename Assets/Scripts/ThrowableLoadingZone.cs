using Unity.VisualScripting;
using UnityEngine;

public class ThrowableLoadingZone : MonoBehaviour
{
    HingeJoint addHingeJoint;
    Collider throwables;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter(throwables);
        OnTriggerExit(throwables);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Throwable"))
        {
            addHingeJoint = other.AddComponent<HingeJoint>();
            //addHingeJoint.anchor();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Throwable") && Input.GetKeyUp(KeyCode.Space))
        {

            HingeJoint hingeJointToDestroy;
            hingeJointToDestroy = other.GetComponent<HingeJoint>();
            Destroy(hingeJointToDestroy);
        }

    }

}   
