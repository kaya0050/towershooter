using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 100;

    public PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            playerStats.bijEnemy = false;
            playerStats.bijBigEnemy = false;
            playerStats.bijSmallEnemy = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
           
            case "Bullet":
                BulletScriptnew bullet = other.GetComponent<BulletScriptnew>();

                if (bullet.slowdown && gameObject.GetComponent<EnemyPathFollowScript>().speed > 1)
                {
                    gameObject.GetComponent<EnemyPathFollowScript>().speed /= 2; 
                }
                Destroy(other.gameObject);
                health -= bullet.damage;
                break;
        }
    }
}
