using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusScript : MonoBehaviour
{
    public cameramovement cameraMovement;
    public gridplace grid;
    public GameObject verdedigingsButton;
    public GameObject upgradeButton;
    public GameObject upgradeScherm;
    public GameObject pauseMenu;

    public bool bouwen = true;
    public bool inBouwFase = true;
    public bool inVerdedigingFase = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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

    public void ResumeGame()
    {
        if (inBouwFase)
        {
            bouwen = true;
            pauseMenu.SetActive(false);
            verdedigingsButton.SetActive(true);
            upgradeButton.SetActive(true);
            cameraMovement.enabled = true;
            Time.timeScale = 1f;
        } 
        else if (inVerdedigingFase)
        {
            Cursor.lockState = CursorLockMode.Locked;
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
