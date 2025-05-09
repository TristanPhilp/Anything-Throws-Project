using UnityEngine;
using System.Collections;


public class WallDamage : MonoBehaviour
{
    //wall variables
    public float wallHealth = 5; //The amount of objects needed to break the wall.
    public float objectBreakTime = 0.5f; //Time till the object disappears after making collision.
    public float wallDestructTime = 0.5f; //Time that it takes for the wall to POOF

    public float summonPrefabTime = 0.01f; //Time that it takes to summon the prefab
    public bool isDead = false; //It wasn't useless.
    public GameObject prefab; //Prefab that gets summoned... please make it only *the wall broken prefab*.. or else the wall will turn into that prefab lol
    
    GameObject collidingObject; //Object that collides with the wall.

    //Sound Variables
    public AudioSource effectPlayer;
    public AudioClip smallDamageSound;
    public AudioClip regularDamageSound;
    public AudioClip mediumDamageSound;
    public AudioClip largeDamageSound;

    //calls wall destructions and destroys object.
    void checkWHealth()
    {
        if (collidingObject != null)
        {

            if (collidingObject.transform.localScale.x > 0.005f)
            {

                collidingObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);

            }




        }

        if(wallHealth < 0)
        {
            wallHealth = 0;
        }
        if (isDead == false && wallHealth == 0)
        {
            Destroy(gameObject.GetComponent<BoxCollider>()); //Destroys the object hitbox.

            StartCoroutine(summonWall (wallDestructTime - summonPrefabTime));
            
            Destroy(gameObject, wallDestructTime); //Destroys our wall.
            Debug.Log("GUP!"); //GUP!!
            isDead = true;
        }
        
    }
    
    IEnumerator summonWall (float delay)
    {

        yield return new WaitForSecondsRealtime(delay);
        MakeWall();

    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    void MakeWall()
    {
        Instantiate(prefab, transform.position, transform.rotation); //Summons prefab on top of the wall.
    }
    void applyDamage(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "Bush":
                wallHealth = wallHealth - 0.5f;
                break;
            case "Tree":
                wallHealth = wallHealth - 2.0f;
                break;
            default:
                wallHealth = wallHealth - 1.0f;
                break;

        }
    }
    void playSound()
    {
        switch (wallHealth)
        {
            case 1:
                effectPlayer.clip = largeDamageSound;
                effectPlayer.Play();
                break;
            case 1.5f:
                effectPlayer.clip = largeDamageSound;
                effectPlayer.Play();
                break;
            case 2:
                effectPlayer.clip = mediumDamageSound;
                effectPlayer.Play();
                break;
            case 2.5f:
                effectPlayer.clip = mediumDamageSound;
                effectPlayer.Play();
                break;
            case 3:
                effectPlayer.clip = regularDamageSound;
                effectPlayer.Play();
                break;
            case 3.5f:
                effectPlayer.clip = regularDamageSound;
                effectPlayer.Play();
                break;
            case 4:
                effectPlayer.clip = smallDamageSound;
                effectPlayer.Play();
                break;
            case 4.5f:
                effectPlayer.clip = smallDamageSound;
                effectPlayer.Play();
                break;
        }

    }

    //checks to see if object hits wall.
    void OnTriggerEnter(Collider other)
    {

        Debug.Log("A object entered the wall's hitbox.");

        
        collidingObject = other.gameObject;

        if (other.gameObject.name != "Player")
        {
            Destroy(other.gameObject, objectBreakTime);
            ParticleSystem ps = GetComponent<ParticleSystem>();
            

            applyDamage(other);
            playSound();

            ps.Play();
            //In a larger level, this would be a randomly selected sound effect, or use if else for ranges. But for now, this serves the purpose better
            
        }

        checkWHealth();

    }



}