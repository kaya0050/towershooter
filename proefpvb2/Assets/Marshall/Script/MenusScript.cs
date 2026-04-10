using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusScript : MonoBehaviour
{
    public cameramovement cameraMovement;
    public gridplace grid;
    public DoelScript doel;
    public manager managerScript;
    public GameObject verdedigingsButton;
    public GameObject upgradeButton;
    public GameObject upgradeScherm;
    public GameObject pauseMenu;

    public GameObject placeMarker;
    public int repareerKosten = 50;

    public bool bouwen = true;
    public bool inBouwFase = true;
    public bool inVerdedigingFase = false;
    public bool pause;
    private void Update()
    {
        placeMarker.SetActive(!inVerdedigingFase);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = true;
            bouwen = false;
            Cursor.lockState = CursorLockMode.None;
            grid.enabled = false;
            cameraMovement.enabled = false;
            verdedigingsButton.SetActive(false);
            upgradeButton.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RepareerDoel()
    {
        if (doel.health < 100)
        {
            managerScript.resources -= repareerKosten;
            doel.health = 100;
        }
    }

    public void ResumeGame()
    {
        if (inBouwFase)
        {
            pause = false;
            bouwen = true;
            pauseMenu.SetActive(false);
            verdedigingsButton.SetActive(true);
            upgradeButton.SetActive(true);
            cameraMovement.enabled = true;
            Time.timeScale = 1f;
        } 
        else if (inVerdedigingFase)
        {
            pause = false;
            Cursor.lockState = CursorLockMode.Locked;
            bouwen = true;
            cameraMovement.enabled = true;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void UpgradeMenu()
    {
        upgradeScherm.SetActive(true);
        grid.enabled = false;
        bouwen = false;
    }

    public void UpgradeMenuSluiten()
    {
        upgradeScherm.SetActive(false);
        grid.enabled = true;
        bouwen = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("merge2");
        Time.timeScale = 1f;
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }
}
