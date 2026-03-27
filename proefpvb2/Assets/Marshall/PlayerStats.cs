using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;

    public bool bijEnemy = false;

    public float takingDamageTimer = 0f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnpoint;

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
        //Teleport player naar een spawnpoint met volle health.
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
