using UnityEngine;

public class AddForce : MonoBehaviour
{
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    bool IsTurned(CatapultController catapultController)
    {
        bool isTurned = catapultController.isTurned;
        return isTurned;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
