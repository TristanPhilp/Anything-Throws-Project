using UnityEngine;

public class TrechubetPlayerInteract : MonoBehaviour
{
    [SerializeField] public bool isPlayerHere = false;
    public Rigidbody weight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            weight.position = new Vector3(-10, 4, 1.75f);
            // weight.transform.Rotate(0,0,0);
            //arm.transform.Rotate(-30.0f, 0.0f, 0.0f);
            weight.isKinematic = true;
            //arm.isKinematic = true;
        }
    }
}
