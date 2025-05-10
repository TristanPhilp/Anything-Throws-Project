using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Collider))]
public abstract class Interactable : MonoBehaviour
{
    public GameObject outline;
    public AudioClip interactSound;
    Collider m_Collider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

    //These functions may not be needed, but oh well
    //All these do is allow interaction to be implemented on any object without needing to tweak the player interact code.
    public virtual void OnHover()
    {
        outline.SetActive(true);
        Debug.Log("This item does not override OnHover");
    }
    public virtual void OffHover()
    {
        outline.SetActive(false);
        Debug.Log("This item does not override OffHover");
    }
    public virtual int OnInteract()
    {
        Debug.Log("This item does not have a definition for OnInteract");
        return 0;
    }
}
