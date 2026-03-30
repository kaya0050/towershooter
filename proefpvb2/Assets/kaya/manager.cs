using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public int resources;
    public KeyCode switchkey;

    public gridplace gridplace;

    public GameObject defenceToPlace;
    public List<GameObject> defences;

    void Start()
    {
        
    }

    void Update()
    {
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
