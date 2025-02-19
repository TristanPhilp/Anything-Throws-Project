using UnityEngine;




[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ThrowableClass : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Collider m_Collider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider> ();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        //activate shader for now
    }
}
