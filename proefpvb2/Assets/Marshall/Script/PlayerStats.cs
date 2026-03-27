using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;

    public bool bijEnemy = false;

    public float takingDamageTimer = 0f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnpoint;
    public Transform respawnPoint;

    void Update()
    {
        TakingDamage();
        Schieten();
    }

    public void Schieten()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
        }
    }

    public void TakingDamage()
    {
        if (bijEnemy)
        {
            takingDamageTimer -= Time.deltaTime;
        }

        if (takingDamageTimer < 0)
        {
            health -= 35;
            takingDamageTimer = 2f;
        }

        if (health <= 0)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint.position + new Vector3(0, 1f, 0);
        transform.rotation = respawnPoint.rotation;
        health = 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Enemy":
                bijEnemy = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Enemy":
                bijEnemy = false;
                takingDamageTimer = 2f;
                break;
        }
    }
}
