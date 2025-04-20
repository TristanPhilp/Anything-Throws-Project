using UnityEngine;

public class WallDamage : MonoBehaviour
{
    //wall variables
    public float wallHealth = 5; //The amount of objects needed to break the wall.
    public float objectBreakTime = 0.1f; //Time till the object disappears after making collision.
    public float wallDestructTime = 0.5f; //Time that it takes for the wall to POOF

    public float summonPrefabTime = 0.01f; //Time that it takes to summon the prefab

    public GameObject prefab; //Prefab that gets summoned... please make it only *the wall broken prefab*.. or else the wall will turn into that prefab lol

    //Sound Variables
    public AudioSource effectPlayer;
    public AudioClip smallDamageSound;
    public AudioClip regularDamageSound;
    public AudioClip mediumDamageSound;
    public AudioClip largeDamageSound;

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

            //In a larger level, this would be a randomly selected sound effect, or use if else for ranges. But for now, this serves the purpose better
            switch (wallHealth)
            {
                case 1:
                    effectPlayer.clip = largeDamageSound;
                    effectPlayer.Play();
                    break;
                case 2:
                    effectPlayer.clip = mediumDamageSound;
                    effectPlayer.Play();
                    break;
                case 3:
                    effectPlayer.clip = regularDamageSound;
                    effectPlayer.Play();
                    break;
                case 4:
                    effectPlayer.clip = smallDamageSound;
                    effectPlayer.Play();
                    break;
            }

        }
    }



}