using UnityEngine;

public class PhaseSwitchScript : MonoBehaviour
{
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
        player.SetActive(false);
        topView.enabled = true;
        firstPerson.enabled = false;
        gridplace.enabled = true;
    }

    public void Verdedigingsfase()
    {
        gridplace.enabled = false;
        player.SetActive(true);
        topView.enabled = false;
        firstPerson.enabled = true;
    }
}
