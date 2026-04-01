using UnityEngine;

public class DoelScript : MonoBehaviour
{
    public int health = 100;

    private void Update()
    {
        if (health <= 0)
        {
            // einde spel.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Enemy":
                Destroy(other.gameObject);
                health -= 35;
                break;
            case "BigEnemy":
                Destroy(other.gameObject);
                health -= 49;
                break;
            case "SmallEnemy":
                Destroy(other.gameObject);
                health -= 20;
                break;
        }
    }
}
