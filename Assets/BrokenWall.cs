using UnityEngine;

public class BrokenWall : MonoBehaviour
{

    public AudioSource effectPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effectPlayer = GetComponent<AudioSource>();
        effectPlayer.time = 5.0f;
        effectPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (effectPlayer.time > 8.5f && effectPlayer.time < 13.0f)
        {
            effectPlayer.time = 13.0f;
        }
    }
}
