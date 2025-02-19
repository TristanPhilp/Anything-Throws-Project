using UnityEngine;

public class WallDamage : MonoBehaviour
{
    public float wallHealth = 5;
    public float objectBreakTime = 0.1f;
    public float wallDestructTime = 0.5f;


    public bool wallBroke = false;

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

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Poopfartius | " + other.gameObject);
        Destroy(other.gameObject, objectBreakTime);
        wallHealth = wallHealth - 1;
    }

    

}