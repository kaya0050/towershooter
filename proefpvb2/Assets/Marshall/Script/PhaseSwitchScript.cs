using UnityEngine;

public class PhaseSwitchScript : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public Camera firstPerson;
    public Camera topView;
    public GameObject player;
    public gridplace gridplace;

    void Start()
    {
        player.SetActive(false);
        topView.enabled = true;
        firstPerson.enabled = false;
        gridplace.enabled = true;
    }

    public void Bouwfase()
    {
        Cursor.lockState = CursorLockMode.None;
        player.SetActive(false);
        topView.enabled = true;
        firstPerson.enabled = false;
        gridplace.enabled = true;
    }

    public void Verdedigingsfase()
    {
        Cursor.lockState= CursorLockMode.Locked;
        gridplace.enabled = false;
        player.SetActive(true);
        topView.enabled = false;
        firstPerson.enabled = true;

        StartCoroutine(waveSpawner.StartNextWave());
    }
}
