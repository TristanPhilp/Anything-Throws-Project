using System;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class TrebuchetController : MonoBehaviour
{
    [Header("Trebuchet Components")]
    public GameObject arm;
    public Quaternion primedPos;
    public Quaternion restPos;
    public bool atRest;
    public Animator animator;

    [Header("Objects launch")]
    public GameObject launchable;

    //Used to play the launching sound
    AudioSource launchPlayer;
    public AudioSource audioPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        atRest = false;
        launchPlayer = GetComponent<AudioSource>();
    }

    //function for throwing
    public void TryLaunch()
    {
        if (atRest == false)
        {

            //if there's a throwable in the zone, then add velocity to it and forget the throwable
            if (launchable != null) 
            {
                launchable.GetComponent<Rigidbody>().linearVelocity = new Vector3(-20, 15, 0);
                launchable = null;
            }
            Debug.Log("Launching");
            animator.Play("Fling");
            atRest = true;
        }
        else
        {
            animator.Play("Reset");
            atRest = false;
        }
    }
}
