using Unity.VisualScripting;
using UnityEngine;

public class BulletScriptnew : MonoBehaviour
{
    public float speed = 20f;
    public float destroyTimer = 2f;
    public int damage = 10;
    private Rigidbody rb;
    public bool slowdown = false;
    public bool homing = false;
    public GameObject targetEnemy;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
    }

    void Update()
    {
        if (homing && targetEnemy)
        {
            Vector3 direction = (targetEnemy.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

            rb.linearVelocity = direction * speed;
        }
        else if (rb.linearVelocity != Vector3.zero && !homing)
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
