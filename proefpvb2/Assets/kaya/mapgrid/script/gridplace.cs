using System.Collections.Generic;
using UnityEngine;

public class gridplace : MonoBehaviour
{
    public GameObject objectToPlace;
    public float gridSize = 1;

    public GameObject placeMarker;
    private List<Vector3> occupiedTiles = new List<Vector3>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        GetPlaceMarkerGridPos();

        if (Input.GetMouseButtonDown(0))
        {
            PlaceMarker();
        }
    }
    void GetPlaceMarkerGridPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 location = hit.point;
            Vector3 gridLockedPos = new Vector3(
                Mathf.Round(location.x/gridSize) * gridSize,
                Mathf.Round(location.y / gridSize) * gridSize,
                Mathf.Round(location.z / gridSize) * gridSize


            );

            placeMarker.transform.position = gridLockedPos;
        }
    }

    void PlaceMarker()
    {
        Vector3 placementPos = placeMarker.transform.position;

        if(!occupiedTiles.Contains(placementPos))
        {
            Instantiate(objectToPlace,placementPos,Quaternion.identity);

            occupiedTiles.Add(placementPos);
        }
    }
   
}
