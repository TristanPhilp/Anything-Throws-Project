using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class ThrowableClass : Interactable
{

    Rigidbody m_Rigidbody;
    Collider m_collider;

    AudioSource audioPlayer;
    bool isHeld;

    Transform outlineFind;

    MeshRenderer outline;

    public AudioClip collideSound;
    public AudioClip launchSound;
    public float pickupScale;
    private float orginalScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isHeld = false;
        outlineFind = transform.Find("Outline");
        outline = outlineFind.GetComponent<MeshRenderer>();
        m_collider = GetComponent<MeshCollider>();
        m_Rigidbody = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
        m_Rigidbody.Sleep();
        orginalScale = transform.localScale.x;
    }

    public override void OnHover()
    {
        outline.enabled = true;
    }

    public override void OffHover()
    {
        outline.enabled = false;
    }

    //interactation code
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

    //returns hold object
    void Hold()
    {
        isHeld = true;
        transform.localScale = new Vector3(pickupScale, pickupScale, pickupScale);
        gameObject.layer = LayerMask.NameToLayer("HeldObject");
    }
    //returns drop object
    void Drop()
    {
        isHeld = false;
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    public void OnLaunch()
    {
        transform.localScale = new Vector3(orginalScale, orginalScale, orginalScale);
        audioPlayer.clip = launchSound;
        audioPlayer.Play();
    }

    public void OnWallHit()
    {
        audioPlayer.clip = collideSound;
        audioPlayer.Play();
    }
}
