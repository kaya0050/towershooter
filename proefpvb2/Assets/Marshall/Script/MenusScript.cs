using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject verdedigingsButton;
    public cameramovement cameraMovement;
    public gridplace grid;

    public bool inBouwFase = false;
    public bool inVerdedigingFase = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            verdedigingsButton.SetActive(false);
            grid.enabled = false;
            cameraMovement.enabled = false;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        if (inBouwFase)
        {
            cameraMovement.enabled = true;
            verdedigingsButton.SetActive(true);
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
        else if (inVerdedigingFase)
        {
            Cursor.lockState = CursorLockMode.Locked;
            cameraMovement.enabled = true;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
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
