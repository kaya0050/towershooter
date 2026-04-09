using UnityEngine;

public class DoelScript : MonoBehaviour
{
    public GameObject deathScherm;

    public int health = 100;
    manager managerScript;
    public void Start()
    {
        managerScript = FindFirstObjectByType<manager>();
    }
    private void Update()
    {
        if (health <= 0)
        {
            health = 0;
            deathScherm.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Enemy":
                managerScript.enemies.Remove(gameObject);
                other.gameObject.GetComponent<EnemyStats>().health = 0;
                health -= 35;
                break;
            case "BigEnemy":
                managerScript.enemies.Remove(gameObject);
                other.gameObject.GetComponent<EnemyStats>().health = 0;
                health -= 49;
                break;
            case "SmallEnemy":
                managerScript.enemies.Remove(gameObject);
                other.gameObject.GetComponent<EnemyStats>().health = 0;
                health -= 20;
                break;
        }
    }
}
