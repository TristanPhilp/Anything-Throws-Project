using UnityEngine;

public class WallDamage
{
    public float wallHealth = 100;


    private void OnTriggerEnter(Collider other)
    {
        wallHealth = wallHealth - 2;
    }

}
