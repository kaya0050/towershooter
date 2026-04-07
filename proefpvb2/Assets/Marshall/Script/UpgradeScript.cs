using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public int fireRateUpgradeCost = 25;
    public int speedUpgradeCost = 25;
    public int healthUpgradeCost = 25;

    public PlayerStats stats;
    public PlayerMovement movement;
    public manager managerScript;

    public void UpgradeHealth()
    {
        if (stats.maxHealth < 250 && managerScript.resources > healthUpgradeCost)
        {
            managerScript.resources -= healthUpgradeCost;
            stats.maxHealth += 25;
            healthUpgradeCost = Mathf.CeilToInt(healthUpgradeCost * 1.5f);
        }
    }

    public void UpgradeSpeed()
    {
        if (movement.moveSpeed < 12f && managerScript.resources > speedUpgradeCost)
        {
            managerScript.resources -= speedUpgradeCost;
            movement.moveSpeed += 1f;
            movement.sprintSpeed += 1f;
            speedUpgradeCost = Mathf.CeilToInt(speedUpgradeCost * 1.5f);
        }
    }

    public void UpgradeFireRate()
    {
        if (stats.fireCooldownUpgrade > .3f && managerScript.resources > fireRateUpgradeCost)
        {
            managerScript.resources -= fireRateUpgradeCost;
            stats.fireCooldownUpgrade -= .1f;
            fireRateUpgradeCost = Mathf.CeilToInt(fireRateUpgradeCost * 1.5f);
        }
    }
}
