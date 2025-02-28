using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public UnityEvent onHover;
    public UnityEvent onInteract;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //These functions may not be needed, but oh well
    public void OnHover()
    {
        onHover.Invoke();
    }
    public void OnInteract()
    {
        onInteract.Invoke();
    }
}
