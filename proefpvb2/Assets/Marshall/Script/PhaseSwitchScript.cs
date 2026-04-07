using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhaseSwitchScript : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public Camera firstPerson;
    public Camera topView;
    public GameObject player;
    public gridplace gridplace;
    public MenusScript menu;
    public GameObject[] defences;

    void Start()
    {
        player.SetActive(false);
        topView.enabled = true;
        firstPerson.enabled = false;
        gridplace.enabled = true;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && waveSpawner.isSpawning == false)
        {
            menu.bouwen = true;
            Bouwfase();
        }
    }

    public void Bouwfase()
    {
        if (menu.bouwen == true)
        {
            Cursor.lockState = CursorLockMode.None;
            player.SetActive(false);
            topView.enabled = true;
            firstPerson.enabled = false;
            gridplace.enabled = true;
            menu.inBouwFase = true;
            menu.inVerdedigingFase = false;
        }
    }

    public void Verdedigingsfase()
    {
        defences = GameObject.FindGameObjectsWithTag("defence");
        defloop(true);
        Cursor.lockState= CursorLockMode.Locked;
        gridplace.enabled = false;
        player.SetActive(true);
        topView.enabled = false;
        firstPerson.enabled = true;
        menu.inVerdedigingFase = true;
        menu.inBouwFase = false;

        StartCoroutine(waveSpawner.StartNextWave());
    }
    void defloop(bool bl)
    {
        foreach (var item in defences)
        {
            item.GetComponent<defence>().active = bl;
        }
    }
}
