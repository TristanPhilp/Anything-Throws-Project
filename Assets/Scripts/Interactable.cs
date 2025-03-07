using UnityEngine;


[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    Collider m_Collider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //These functions may not be needed, but oh well
    //All these do is allow interaction to be implemented on any object without needing to tweak the player interact code.
    public virtual void OnHover()
    {
        Debug.Log("This item does not have a definition for OnHover");
    }
    public virtual void OffHover()
    {
        Debug.Log("This item does not have a definition for OffHover");
    }
    public virtual void OnInteract()
    {
        Debug.Log("This item does not have a definition for OnInteract");
    }
}
