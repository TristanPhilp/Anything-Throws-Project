using UnityEngine;

public class WallDamage : MonoBehaviour
{
    //wall variables
    public float wallHealth = 5; //The amount of objects needed to break the wall.
    public float objectBreakTime = 0.1f; //Time till the object disappears after making collision.
    public float wallDestructTime = 0.5f; //Time that it takes for the wall to POOF


    public GameObject prefab; //Prefab that gets summoned... please make it only *the wall broken prefab*.. or else the wall will turn into that prefab lol

    public bool wallBroke = false; //is the wall broke?
                                   //ngl probably serves like 0 purpose but im keeping this just incase.

    //calls wall destructions and destroys object.
    void Update()
    {
        if (wallBroke == false)
        {
            if (wallHealth <= 0)
            {
                Destroy(gameObject, wallDestructTime);
                Debug.Log("GUP!");

                Invoke("makeWall", (wallDestructTime - 0.01f));

                wallBroke = true;
            }
        }
    }

    void makeWall()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    //checks to see if object hits wall.
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("A object enterefd.");

        Debug.Log("Poopfartius | " + other.gameObject);
        if (other.gameObject.name != "Player")
        {
            Destroy(other.gameObject, objectBreakTime);
            wallHealth = wallHealth - 1;
        }
    }



}