using System.Linq;
using UnityEngine;

public class EnemyPathFollowScript : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float rotationSpeed = 5f;

    private int currentWaypointIndex = 0;

    private void Start()
    {
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("checkpoint");

        waypoints = waypointObjects
            .OrderBy(wp => wp.name)
            .Select(wp => wp.transform)
            .ToArray();
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypointIndex];
        Vector3 direction = (target.position - transform.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            currentWaypointIndex++;
        }
    }
}
