using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public int resources;
    public KeyCode switchkey;

    public gridplace gridplace;
    public MenusScript MenusScript;
    private GameObject defenceToPlace;
    public List<GameObject> defences;
    public List<GameObject> enemies;
    public bool speedup;
    public float speedupamount;
    void Start()
    {
        defenceToPlace = defences[0];
    }

    void Update()
    {
        if (speedup && !MenusScript.pause)
        {
            Time.timeScale = speedupamount;
        }
        else if (!MenusScript.pause) 
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
