using UnityEngine;

public class BounceText : MonoBehaviour
{
    public float speed = 1f;
    public float amount = 0.05f;

    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * speed) * amount;
        transform.localScale = startScale * scale;
    }
}
