using TMPro;
using UnityEngine;

public class InterfaceScript : MonoBehaviour
{
    public PlayerStats stats;
    public manager managerScript;
    public WaveSpawner wave;
    public DoelScript doel;

    public TextMeshProUGUI healthDoel;
    public TextMeshProUGUI healthPlayer;
    public TextMeshProUGUI kogels;
    public TextMeshProUGUI aantalVijanden;
    public TextMeshProUGUI currentWave;
    public TextMeshProUGUI resources;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && managerScript.speedup == false)
        {
            managerScript.speedup = true;
        }
        else
        {
            managerScript.speedup = false;
        }

            aantalVijanden.text = $"{wave.verslagenVijanden} / {wave.teSpawnenVijanden}";
        healthPlayer.text = $"{stats.health} / {stats.maxHealth}";
        healthDoel.text = $"{doel.health} / 100";
        kogels.text = $"{stats.kogels} / 30";
        resources.text = $"resources: {managerScript.resources}";
    }

    public void updateWave()
    {
        currentWave.text = $"{wave.currentWaveIndex + 1} / {wave.waves.Length}";
    }
}
