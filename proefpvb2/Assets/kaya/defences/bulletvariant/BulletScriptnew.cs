using Unity.VisualScripting;
using UnityEngine;

public class BulletScriptnew : MonoBehaviour
{
    public float speed = 20f;
    public float destroyTimer = 2f;

    private Rigidbody rb;
    public bool slowdown = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
    }

    void Update()
    {
        if (rb.linearVelocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(rb.linearVelocity) * Quaternion.Euler(90f, 0f, 0f);
        }

        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
