using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class ThrowableClass : Interactable
{
    public GameObject player;
    public Joint guidePoint;
    Collider playerCollider;
    Rigidbody m_Rigidbody;
    Renderer rend;
    bool isHeld;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCollider = player.GetComponent<Collider>();
        guidePoint = player.GetComponentInChildren<Camera>().GetComponentInChildren<Joint>();
        isHeld = false;
        m_Rigidbody = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public override void OnHover()
    {
        ColorShift(Color.white);
    }
    public override void OnInteract()
    {
        //activate shader for now
        Debug.Log("Throwable Object Selected");
        if (!isHeld)
        {
            Hold();
        }
        else
        {
            Drop();
        }
    }

    void Hold()
    {
        isHeld = true;
        //m_Rigidbody.isKinematic = true;
        guidePoint.connectedBody = m_Rigidbody;
        m_Rigidbody.useGravity = false;
        //m_Collider.excludeLayers = 1 << LayerMask.NameToLayer("Player");
        gameObject.layer = LayerMask.NameToLayer("HeldObject");
        ColorShift(Color.red);
    }

    void Drop()
    {
        isHeld = false;
        //m_Rigidbody.isKinematic = false;
        guidePoint.connectedBody = null;
        m_Rigidbody.useGravity = true;
        //m_Collider.excludeLayers = 0;
        gameObject.layer = LayerMask.NameToLayer("Default");
        ColorShift(Color.blue);
    }

    //Interacts with the current material to set the material color to the input color.
    public void ColorShift(Color color)
    {
        rend.material.color = color;
    }
}
