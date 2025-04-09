using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    //camera vairables
    [SerializeField] private Camera _camera;

    public float camRotateY = .05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0, camRotateY, 0 );

        //if (_camera.transform.rotation == 90f)
        { 
        
        }
    }
}
