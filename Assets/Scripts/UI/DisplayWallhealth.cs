using System;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWallhealth : MonoBehaviour
{
    public GameObject wallGameObject;
    private float currentHealth;
    private float maxHealth;
    private GameObject healthBarGameObject;
    private WallDamage sceneWallDamage;

    private void Start()
    {
        healthBarGameObject = GameObject.Find("bar"); //make sure the object for the healthbar is actually set.
        sceneWallDamage = wallGameObject.GetComponent<WallDamage>(); //connects to wall damage script
        maxHealth = sceneWallDamage.wallHealth; //sets max health at the beginning of the scene. Since there isn't a max health variable for some reason, just grab the health as the object is made.
        currentHealth = sceneWallDamage.wallHealth; // do the same for current health when the scene is created.
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = (float)sceneWallDamage.wallHealth; //update current health
        float ratio = (float)currentHealth / (float)maxHealth; //create a ratio to scale the health bar by.
        healthBarGameObject.transform.localScale = Vector3.Lerp(healthBarGameObject.transform.localScale, new Vector3(ratio, 1, 1), 0.02f); //scale the health bar's x axis using a lerp. Lerping is done to make it look smooth.
    }
}
