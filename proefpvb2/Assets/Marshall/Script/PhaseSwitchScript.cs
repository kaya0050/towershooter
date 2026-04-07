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
    public GameObject[] defences;

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
        defences = GameObject.FindGameObjectsWithTag("defence");
        defloop(true);
        Cursor.lockState= CursorLockMode.Locked;
        gridplace.enabled = false;
        player.SetActive(true);
        topView.enabled = false;
        firstPerson.enabled = true;

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
