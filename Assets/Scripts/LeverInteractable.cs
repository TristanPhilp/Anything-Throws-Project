using UnityEngine;

public class LeverInteractable : Interactable
{
    public GameObject launcher;


    public override int OnInteract()
    {
        launcher.GetComponent<TrebuchetController>().TryLaunch();
        return 0;
    }
}
