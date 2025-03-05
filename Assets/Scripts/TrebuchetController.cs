using Unity.Burst.Intrinsics;
using UnityEngine;

public class TrebuchetController : MonoBehaviour
{
    [Header("Objects launch")]
    //public Rigidbody weight;
    public Rigidbody arm;
    //HingeJoint hingeJointToDestroy;
    public GameObject launchable;

    [Header("Player Properties")]
    public bool isPlayerHere;
    public GameObject PlayerObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerHere == true)
        {
            arm.transform.rotation = new Quaternion();
            //weight.isKinematic = false;
            //arm.isKinematic = false;

        }

        if (Input.GetKeyUp(KeyCode.Space) && isPlayerHere == true)
        {
            arm.MoveRotation(new Quaternion(0, 0, 0, 0));
            // HingeJoint hingeJointToDestroy;
            //hingeJointToDestroy = launchable.GetComponent<HingeJoint>();
            //Destroy(hingeJointToDestroy);

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
}
