using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTrigger : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform targetPoint;
    public GameObject platform;
    public float speed = 2f;
    private bool move = false;
    private Vector3 lastPosition;
    public Vector3 Velocity { get; private set; }

    void Start()
    {
        move = false;
        spawnPoint.parent = platform.transform.parent;
        targetPoint.parent = platform.transform.parent;
    }
    void Update()
    {
        if (move)
        {
            Velocity = (platform.transform.position - lastPosition) / Time.deltaTime;
            lastPosition = platform.transform.position;
            
            platform.transform.position = Vector3.MoveTowards(platform.transform.position,targetPoint.position,speed * Time.deltaTime);
            if (Vector3.Distance(platform.transform.position, targetPoint.position) < 0.1f)
            {
                move = false;
                Velocity = Vector3.zero;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            move = true;
        }
    }
}