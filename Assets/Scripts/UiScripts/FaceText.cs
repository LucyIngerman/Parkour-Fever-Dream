using UnityEngine;

public class BillboardText : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.LookAt(cam.transform);
        transform.Rotate(0,180,0);
    }
}