using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 100;

    public PlayerStats playerStats;
    public manager managerScript;
    public PhaseSwitchScript phases;

    private void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        managerScript = FindFirstObjectByType<manager>();
        phases = FindFirstObjectByType<PhaseSwitchScript>();
    }

    void Update()
    {
        if (health <= 0)
        {
            phases.levendeEnemies--;
            managerScript.resources += 10;
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

                if (bullet.isSlowdown && gameObject.GetComponent<EnemyPathFollowScript>().speed > 1)
                {
                    gameObject.GetComponent<EnemyPathFollowScript>().speed /= 2; 
                }
                if (bullet.isBomb == false)
                {
                   
                    Destroy(other.gameObject);
                }
                else
                {
                    Instantiate(bullet.bomb, transform.position, Quaternion.identity);
                }
                
                health -= bullet.damage;
                break;
            case "Bomb":
                health -= 100;
                break;
        }
    }
}
