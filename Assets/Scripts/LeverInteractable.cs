using UnityEngine;

public class LeverInteractable : Interactable
{
    public GameObject launcher;


    //sees if object is launchable
    public override int OnInteract()
    {
        launcher.GetComponent<TrebuchetController>().TryLaunch();
        return 0;
    }
}
