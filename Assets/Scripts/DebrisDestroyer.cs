using UnityEngine;

public class DebrisDestroyer : MonoBehaviour
{

    bool canDespawn = false;

    void Start()
    {
        Destroy(gameObject, Random.Range(8.0f, 12.0f)); //Destroys our debris.
        Invoke("canDestroy", 2.75f);


    }
    void Update()
    {


        gameObject.GetComponent<Rigidbody>().AddForce(transform.up * -6000.81f);
        

        if (canDespawn)
        {
            if (transform.localScale.x > 0.001f)
            {
                transform.localScale -= new Vector3(0.003f, 0.003f, 0.003f);

            }

            if (transform.localScale.x < 0f)
            {
                Destroy(gameObject); //This makes it so that if the object is so small you can barely see it, it'll just despawn.
            }

        }
    }

    void canDestroy()
    {
        canDespawn = true;
    }

}
