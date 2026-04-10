using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PhaseSwitchScript : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public Camera firstPerson;
    public Camera topView;
    public GameObject player;
    public GameObject upgradeButton;
    public GameObject verdedigingsfaseButton;
    public GameObject repareerButton;
    public GameObject hud;
    public TextMeshProUGUI resourceText;
    public gridplace gridplace;
    public MenusScript menu;
    public GameObject[] defences;

    public int levendeEnemies;

    void Start()
    {
        player.SetActive(false);
        topView.enabled = true;
        firstPerson.enabled = false;
        gridplace.enabled = true;
        hud.SetActive(false);
    }

    void Update()
    {
        if (levendeEnemies == 0 && waveSpawner.isSpawning == false)
        {
            Bouwfase();
        }
    }

    public void Bouwfase()
    {
        if (menu.bouwen == true)
        {
            hud.SetActive(false);
            resourceText.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            player.SetActive(false);
            repareerButton.SetActive(true);
            verdedigingsfaseButton.SetActive(true);
            upgradeButton.SetActive(true);
            topView.enabled = true;
            firstPerson.enabled = false;
            gridplace.enabled = true;
            menu.inBouwFase = true;
            menu.inVerdedigingFase = false;
        }
    }

    public void Verdedigingsfase()
    {
        hud.SetActive(true);
        resourceText.enabled = false;
        defences = GameObject.FindGameObjectsWithTag("defence");
        defloop(true);
        Cursor.lockState= CursorLockMode.Locked;
        gridplace.enabled = false;
        player.SetActive(true);
        repareerButton.SetActive(false);
        verdedigingsfaseButton.SetActive(false);
        upgradeButton.SetActive(false);
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
