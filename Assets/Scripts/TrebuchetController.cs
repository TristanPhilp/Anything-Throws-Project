using System;
using System.Xml.Serialization;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class TrebuchetController : MonoBehaviour
{
    [Header("Trebuchet Components")]
    public bool atRest;
    public Animator animator;

    [Header("Objects launch")]
    public GameObject launchable;
    public Vector3 launchVelocity;

    //Used to play the launching sound
    public AudioSource audioPlayer;
    public AudioClip launchSound;
    public AudioClip resetSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //atRest = false;
        audioPlayer = GetComponent<AudioSource>();
    }


    //function for throwing
    public void TryLaunch()
    {
        //if (atRest == false)
        //{
            //if there's a throwable in the zone, then add velocity to it and forget the throwable
            Debug.Log("Launching");
            animator.Play("Fling");
            audioPlayer.clip = launchSound;
            audioPlayer.Play();
            //atRest = true;
        //}
        //else
        //{
            //animator.Play("Reset");
           // audioPlayer.clip = resetSound;
            //audioPlayer.Play();
           //atRest = false;
        //}
    }

    public void Eject()
    {
        if (launchable != null) {

            launchable.layer = LayerMask.NameToLayer("Flying");
            Rigidbody launchableRigidbody = launchable.GetComponent<Rigidbody>();
            Debug.Log("Throwable Ejected");
            if (launchable != null)
            {
                launchable.transform.SetParent(null);
                launchableRigidbody.isKinematic = false;

                launchableRigidbody.linearVelocity = launchVelocity;

                launchable.GetComponent<ThrowableClass>().OnLaunch();
                launchable = null;
            }
        }
    }
}
