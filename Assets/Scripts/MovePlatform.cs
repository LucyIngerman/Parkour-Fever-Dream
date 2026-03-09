using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class MovePlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float maxSpeed = 2f;
    public float acceleration = 3f;
    Vector3 target;
    public float Velocity { get; private set; }
    void Start()
    {
        pointA.parent = transform.parent;
        pointB.parent = transform.parent;
        transform.position = pointA.position;
        target = pointA.position;
    }
    void Update()
    {   
        Velocity = Mathf.MoveTowards(Velocity, maxSpeed, acceleration * Time.deltaTime);

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            Velocity * 0.1f * Time.deltaTime * Vector3.Distance(pointA.position, pointB.position)
        );

        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
            Velocity = 0f;
        }
    }
}