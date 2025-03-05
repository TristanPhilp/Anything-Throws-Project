using Unity.Burst.Intrinsics;
using UnityEngine;

public class CatapultController : MonoBehaviour
{
    [Header("Objects launch")]
   // public Rigidbody weight;
    public Rigidbody arm;
    public bool isTurned = false;
    //HingeJoint hingeJointToDestroy;
   // public GameObject launchable;

    [Header("Player Properties")]
    public bool isPlayerHere;
    public GameObject PlayerObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerHere == true)
        {



            if (isTurned == false)
            {
                isTurned = true;
                arm.rotation = Quaternion.Euler(0, 0, 125);
            }
            else if (isTurned == true)
            {
                isTurned = false;
                arm.rotation = Quaternion.Euler(0, 0, 45);
            }
            // weight.isKinematic = false;
            // arm.isKinematic = false;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerHere = true;
            Debug.Log("Im here");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerHere = false;
            isTurned = false;
            arm.rotation = Quaternion.Euler(0, 0, 45);
            Debug.Log("Im  not here");
            // weight.position = new Vector3(0, 4f, 1.75f);
            // weight.transform.Rotate(0, 0, 0);
           // arm.MovePosition(new Vector3(-3.731045f, 4.8f, 0));
            //arm.rotation = Quaternion.Euler(0, 0, 0);
            //arm.position = new Vector3(0, 4.449043f, 2.107876f);
            //arm.transform.Rotate(-0.046f, 0.0f, 0.0f);

            //weight.isKinematic = true;
            //arm.isKinematic = true;
        }
    }
}
