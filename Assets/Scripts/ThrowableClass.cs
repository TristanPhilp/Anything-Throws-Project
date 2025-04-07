using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class ThrowableClass : Interactable
{

    Rigidbody m_Rigidbody;
    Collider m_collider;

    public Material[] materials;

    AudioSource audioPlayer;

    Renderer rend;
    bool isHeld;

    MeshRenderer outline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isHeld = false;
        outline = transform.GetChild(0).GetComponent<MeshRenderer>();
        m_collider = GetComponent<Collider>();
        m_Rigidbody = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        materials = rend.materials;
        audioPlayer = GetComponent<AudioSource>();
        m_Rigidbody.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public override void OnHover()
    {
        outline.enabled = true;
    }

    public override void OffHover()
    {
        outline.enabled = false;
    }

    public override int OnInteract()
    {
        m_Rigidbody.WakeUp();
        audioPlayer.clip = interactSound;
        audioPlayer.Play();
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
        return 1;
    }

    void Hold()
    {
        isHeld = true;
        gameObject.layer = LayerMask.NameToLayer("HeldObject");
        //ColorShift(Color.red);
    }

    void Drop()
    {
        isHeld = false;
        gameObject.layer = LayerMask.NameToLayer("Default");
        //ColorShift(Color.blue);
    }

    //Interacts with the current material to set the material color to the input color.
    public void ColorShift(Color color)
    {
        materials[0].color = color;
    }

    public void OnLaunch()
    {

    }

    public void OnWallHit()
    {

    }
}
