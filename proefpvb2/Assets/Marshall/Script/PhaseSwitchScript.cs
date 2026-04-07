using UnityEngine;

public class PhaseSwitchScript : MonoBehaviour
{
    public GameObject button;
    public WaveSpawner waveSpawner;
    public Camera firstPerson;
    public Camera topView;
    public GameObject player;
    public gridplace gridplace;
    public MenusScript menu;

    void Start()
    {
        menu.inBouwFase = true;
        player.SetActive(false);
        topView.enabled = true;
        firstPerson.enabled = false;
        gridplace.enabled = true;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Bouwfase();
        }
    }

    public void Bouwfase()
    {
        Cursor.lockState = CursorLockMode.None;
        player.SetActive(false);
        topView.enabled = true;
        firstPerson.enabled = false;
        gridplace.enabled = true;
        button.SetActive(true);
        menu.inBouwFase = true;
        menu.inVerdedigingFase = false;
    }

    public void Verdedigingsfase()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gridplace.enabled = false;
        player.SetActive(true);
        topView.enabled = false;
        firstPerson.enabled = true;
        button.SetActive(false);
        menu.inVerdedigingFase = true;
        menu.inBouwFase = false;

        StartCoroutine(waveSpawner.StartNextWave());
    }
}
