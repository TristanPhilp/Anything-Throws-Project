using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class TrechubetLoadingArea : MonoBehaviour
{
   
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    public Rigidbody weight;
    //public GameObject Throwable;

    Vector3 objectPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Throwable"))
        {
          //  HingeJoint hingeJointToInstaniate = other.AddComponent<HingeJoint>();
        }
    }

}
