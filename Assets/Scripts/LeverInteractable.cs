using System.Collections;
using UnityEngine;

public class LeverInteractable : Interactable
{
    public GameObject launcher;
    public AudioSource audioSource;

    public Vector3 flipPos;
    public Quaternion unflipPos;

    //All this does is send a message to the trebuchet telling it to launch, then tells the interaction code that it's not a throwable object.

    public void Start()
    {
        unflipPos = transform.rotation;
        audioSource.clip = interactSound;
    }
    public override int OnInteract()
    {
        launcher.GetComponent<TrebuchetController>().TryLaunch();
        Flip();
        StartCoroutine(UnFlip());
        return 0;
    }

    public void Flip()
    {

        transform.rotation = Quaternion.Euler(flipPos);

        audioSource.Play();
    }
    IEnumerator UnFlip()
    {
        yield return new WaitForSeconds(8);
        transform.rotation = unflipPos;
        audioSource.Play();
    }
}
