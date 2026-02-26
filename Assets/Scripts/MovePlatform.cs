using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Rigidbody rb;
    private Vector3 target;
    void Start()
    {
        target = pointA.position;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA.position, pointB.position, t);
        rb.MovePosition(Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime));

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