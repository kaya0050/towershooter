using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public int resources;
    public KeyCode switchkey;

    public gridplace gridplace;

    private GameObject defenceToPlace;
    public List<GameObject> defences;
    public List<GameObject> enemies;
    public bool speedup;
    public bool speedupnot;
    public float speedupamount;
    void Start()
    {
        defenceToPlace = defences[0];
    }

    void Update()
    {
        if (speedup)
        {
            Time.timeScale = speedupamount;
        }
        else if (speedupnot)
        {
            Time.timeScale = 1.0f;
        }
        defenceToPlace = defences[0];
        gridplace.objectToPlace = defenceToPlace;

        if (Input.GetKeyDown(switchkey))
        {
            GameObject switchObj = defences[0];
            defences.RemoveAt(0);
            defences.Add(switchObj);

        }
        
    }
}
