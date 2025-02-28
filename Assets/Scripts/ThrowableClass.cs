using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ThrowableClass : MonoBehaviour
{ 
    public GameObject player;
    public Camera playerCam;
    Rigidbody m_Rigidbody;
    Collider m_Collider;
    Renderer rend;
    bool isHeld;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCam = player.GetComponentInChildren<Camera>();
        isHeld = false;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider> ();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Hover()
    {
        ColorShift(Color.white);
    }
    public void Select()
    {
        //activate shader for now
        Debug.Log("Throwable Object Selected");
        if (!isHeld)
        {
            Hold();
            ColorShift(Color.red);
        }
        else
        {
            Drop();
            ColorShift(Color.blue);
        }
    }

    void Hold()
    {
        isHeld = true;
        m_Rigidbody.isKinematic = true;
        transform.parent = playerCam.transform;
    }

    void Drop()
    {
        isHeld = false;
        m_Rigidbody.isKinematic = false;
        transform.parent = null;
    }

    public void ColorShift(Color color)
    {
        rend.material.color = color;
    }
}
