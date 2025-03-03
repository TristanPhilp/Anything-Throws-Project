using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider))]
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
    //All these do is allow interaction to be implemented on any object without needing to tweak the player interact code.
    public void OnHover()
    {
        onHover.Invoke();
    }
    public void OnInteract()
    {
        onInteract.Invoke();
    }
}
