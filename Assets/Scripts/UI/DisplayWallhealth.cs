using System;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWallhealth : MonoBehaviour
{
    public GameObject wallGameObject;
    public int currentHealth = 10;
    private int maxHealth = 100; 
    private GameObject healthBarGameObject;

    private void Start()
    {
        healthBarGameObject = GameObject.Find("bar"); //make sure the object for the healthbar is actually set.
    }

    // Update is called once per frame
    void Update()
    {
        float ratio = (float)currentHealth / (float)maxHealth;
        healthBarGameObject.transform.localScale = Vector3.Lerp(healthBarGameObject.transform.localScale, new Vector3(ratio, 1, 1), 0.02f);
    }
}
