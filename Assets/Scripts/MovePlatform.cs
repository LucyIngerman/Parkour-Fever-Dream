using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Vector3 lastPosition;
    public Vector3 Velocity { get; private set; }
    private Vector3 target;
    void Start()
    {
        pointA.parent = null;
        pointB.parent = null;
        transform.position = pointA.position;
        lastPosition = transform.position;
        target = pointA.position;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position, (Mathf.Sin(Time.time * speed * 0.1f) + 1f) / 2f);

        Velocity = (transform.position - lastPosition) / Time.deltaTime;

        lastPosition = transform.position;

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if(target == pointA.position)
            {
                target = pointB.position;
            }
            else
            {
                target = pointA.position;
            }
        }
    }
}