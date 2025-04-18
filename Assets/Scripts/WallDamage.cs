using UnityEngine;

public class WallDamage : MonoBehaviour
{
    //wall variables
    public float wallHealth = 5;
    public float objectBreakTime = 0.1f;
    public float wallDestructTime = 0.5f;


    public bool wallBroke = false;

    //calls wall destructions and destroys object.
    void Update()
    {
        if (wallBroke == false)
        {
            if (wallHealth <= 0)
            {



                Destroy(gameObject, wallDestructTime);
                Debug.Log("GUP!");
                wallBroke = true;
            }
        }
    }

    //checks to see if object hits wall.
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Poopfartius | " + other.gameObject);
        if (other.gameObject.name != "Player")
        {
            Destroy(other.gameObject, objectBreakTime);
            wallHealth = wallHealth - 1;
        }
    }

    

}