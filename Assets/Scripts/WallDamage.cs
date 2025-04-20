using UnityEngine;

public class WallDamage : MonoBehaviour
{
    //wall variables
    public float wallHealth = 5; //The amount of objects needed to break the wall.
    public float objectBreakTime = 0.1f; //Time till the object disappears after making collision.
    public float wallDestructTime = 0.5f; //Time that it takes for the wall to POOF

    public float summonPrefabTime = 0.01f; //Time that it takes to summon the prefab

    public GameObject prefab; //Prefab that gets summoned... please make it only *the wall broken prefab*.. or else the wall will turn into that prefab lol

    //calls wall destructions and destroys object.
    void Update()
    { 
        if (wallHealth <= 0)
        {
            Destroy(gameObject.GetComponent<BoxCollider>()); //Destroys the object hitbox.

            Invoke("makeWall", (wallDestructTime - summonPrefabTime)); //Summons the wall on a delay.
            Destroy(gameObject, wallDestructTime); //Destroys our wall.
            Debug.Log("GUP!"); //GUP!!

        }
        
    }

    void makeWall()
    {
        Instantiate(prefab, transform.position, transform.rotation); //Summons prefab on top of the wall.
    }

    //checks to see if object hits wall.
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("A object entered the wall's hitbox.");

        if (other.gameObject.name != "Player")
        {
            Destroy(other.gameObject, objectBreakTime);
            wallHealth = wallHealth - 1;
        }
    }



}