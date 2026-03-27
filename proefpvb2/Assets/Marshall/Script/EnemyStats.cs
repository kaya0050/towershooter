using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 100;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Bullet":
                Destroy(other.gameObject);
                health -= 35;
                break;
        }
    }
}
