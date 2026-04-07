using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

    public bool bijEnemy = false;
    public bool bijSmallEnemy = false;
    public bool bijBigEnemy = false;

    public float takingDamageTimer = 0f;
    public float fireCooldown = 0f;
    public float fireCooldownUpgrade = 1f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnpoint;
    public Transform respawnPoint;

    void Update()
    {
        TakingDamage();
        Schieten();

        fireCooldown -= Time.deltaTime;
    }

    public void Schieten()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && fireCooldown <= 0)
        {
            Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
            fireCooldown = fireCooldownUpgrade;
        }
    }

    public void TakingDamage()
    {
        if (bijEnemy || bijBigEnemy || bijSmallEnemy)
        {
            takingDamageTimer -= Time.deltaTime;
        }

        if (takingDamageTimer < 0 && bijEnemy)
        {
            health -= 35;
            takingDamageTimer = 2f;
        } else if (takingDamageTimer < 0 && bijBigEnemy)
        {
            health -= 49;
            takingDamageTimer = 2f;
        } else if (takingDamageTimer < 0 && bijSmallEnemy)
        {
            health -= 20;
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
            case "SmallEnemy":
                bijSmallEnemy = true;
                break;
            case "BigEnemy":
                bijBigEnemy = true;
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
            case "SmallEnemy":
                bijSmallEnemy = false;
                takingDamageTimer = 2f;
                break;
            case "BigEnemy":
                bijBigEnemy = false;
                takingDamageTimer = 2f;
                break;
        }
    }
}
