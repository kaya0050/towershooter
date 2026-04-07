using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class defence : MonoBehaviour
{
    public bool canUpgrade;
    public GameObject upgradedTower;
    public int upgradecost;

    public bool active = false;

    public int price;
    public int sellPrice;

    public float range;
    public int firerate;
    private int timer;

    public GameObject bullet;
    public GameObject bulletpoint;

    public GameObject[] enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = firerate;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void FixedUpdate()
    {
        if (active)
        {
            timer--;

            if (timer <= 0)
            {
                GameObject target = GetClosestEnemy();
                if (target != null)
                {
                    bullet.GetComponent<BulletScriptnew>().targetEnemy = target;
                    Vector3 direction = (target.transform.position - bulletpoint.transform.position).normalized;
                    Quaternion rotation = Quaternion.LookRotation(direction);
                    Instantiate(bullet, bulletpoint.transform.position, rotation,this.transform);

                }

                timer = firerate;
            }
        }
       
    }
    GameObject GetClosestEnemy()
    {
        GameObject closest = null;
        float minDistance = range;


        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }
    public void Upgrade()
    {

        Instantiate(upgradedTower,gameObject.transform.position,gameObject.transform.rotation);
        Destroy(gameObject);
        
    }
}
