using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTrigger : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform targetPoint;
    public GameObject platform;
    public float speed = 2f;
    private bool move = false;
    void Start()
    {
        move = false;
        spawnPoint.parent = null;
        targetPoint.parent = null;
    }
    void Update()
    {
        if (move)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position,targetPoint.position,speed * Time.deltaTime);
             if (Vector3.Distance(platform.transform.position, targetPoint.position) < 0.1f)
            {
                move = false;
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