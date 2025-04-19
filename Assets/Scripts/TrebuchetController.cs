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

    //Used to play the launching sound
    public AudioSource audioPlayer;
    public AudioClip launchSound;
    public AudioClip resetSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        atRest = false;
        audioPlayer = GetComponent<AudioSource>();
    }


    //function for throwing
    public void TryLaunch()
    {
        if (atRest == false)
        {

            //if there's a throwable in the zone, then add velocity to it and forget the throwable
            Debug.Log("Launching");
            animator.Play("Fling");
            launchPlayer.clip = launchSound;
            launchPlayer.Play();
            atRest = true;
        }
        else
        {
            animator.Play("Reset");
            launchPlayer.clip = resetSound;
            launchPlayer.Play();
            atRest = false;
        }
    }

    public void Eject()
    {
        Debug.Log("Throwable Ejected");
        launchable.transform.SetParent(null);
        launchable.GetComponent<Rigidbody>().linearVelocity = Vector3.forward;
        launchable = null;
    }
}
