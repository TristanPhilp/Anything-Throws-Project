using UnityEngine;

public class LeverInteractable : Interactable
{
    public GameObject launcher;


    public override void OnInteract()
    {
        launcher.GetComponent<TrebuchetController>().TryLaunch();
    }
}
