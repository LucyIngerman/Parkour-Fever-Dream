using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Vector3 target;
    void Start()
    {
        target = pointA.position;
    }
    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed * 0.2f, 1);
        transform.position = Vector3.Lerp(pointA.position, pointB.position, t);

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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}