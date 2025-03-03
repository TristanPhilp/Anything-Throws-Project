using Unity.Burst.Intrinsics;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
    [Header("Objects launch")]
    public Rigidbody weight;
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

            weight.isKinematic = false;
            arm.isKinematic = false;

        }

        if (Input.GetKeyUp(KeyCode.Space) && isPlayerHere == true)
        {

            HingeJoint hingeJointToDestroy;
            hingeJointToDestroy = launchable.GetComponent<HingeJoint>();
            Destroy(hingeJointToDestroy);
        
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

            weight.position = new Vector3(0, 4f, 1.75f);
            weight.transform.Rotate(0, 0, 0);
            arm.MovePosition(new Vector3(0, 4.8f, 0));
            arm.MoveRotation(new Quaternion(1, 0, 0, 1));
            //arm.position = new Vector3(0, 4.449043f, 2.107876f);
            //arm.transform.Rotate(-0.046f, 0.0f, 0.0f);
            
            weight.isKinematic = true;
            arm.isKinematic = true;
        }
    }
}
