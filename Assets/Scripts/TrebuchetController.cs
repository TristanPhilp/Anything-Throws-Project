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


    [Header("Objects launch")]
    public GameObject launchable;
    public GameObject loadArea;

    //Used to play the launching sound
    AudioSource launchPlayer;
    public AudioSource resetPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        primedPos = Quaternion.Euler(0, 0, -30);
        restPos = Quaternion.Euler(0, 0, 90);
        atRest = false;
        launchPlayer = GetComponent<AudioSource>();
    }

    //function for throwing
    public void TryLaunch()
    {
        if (atRest == false)
        {
            arm.transform.rotation = restPos;
            launchPlayer.Play();

            //if there's a throwable in the zone, then add velocity to it and forget the throwable
            if (launchable != null) 
            {
                launchable.GetComponent<Rigidbody>().linearVelocity = new Vector3(-20, 15, 0);
                launchable = null;
            }
            
            atRest = true;
        }
        else
        {
            resetPlayer.Play();
            arm.transform.rotation = primedPos;
            atRest = false;
        }
    }
}
