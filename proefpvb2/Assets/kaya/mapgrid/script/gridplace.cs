using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class gridplace : MonoBehaviour
{
    public manager Manager;
    public GameObject objectToPlace;
    public float gridSize = 1;
    public GameObject placeMarker;
    public GameObject checkPointMarker;
    public Transform[] waypoints;
    private List<Vector3> occupiedTiles = new List<Vector3>();
    bool upgrade = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");

        waypoints = checkpoints
            .OrderBy(wp => wp.name)
            .Select(wp => wp.transform)
            .ToArray();

        for (int i = 0; i < waypoints.Length; i++)
        {
            Vector3 placePos = GetGridLockedPos(waypoints[i].position);
            waypoints[i].position = placePos + new Vector3(0, 0.5f, 0);

            occupiedTiles.Add(placePos);


            Instantiate(checkPointMarker, placePos + new Vector3(0, 0.5f, 0), transform.rotation);


            if (i < waypoints.Length - 1)
            {
                Vector3 nextPos = GetGridLockedPos(waypoints[i + 1].position);

                float distance = Vector3.Distance(placePos, nextPos);
                int steps = Mathf.RoundToInt(distance);

                for (float j = 1; j < steps; j++)
                {
                    float t = j / steps;
                    Vector3 interpPos = Vector3.Lerp(placePos, nextPos, t);

                    Vector3 gridPos = GetGridLockedPos(interpPos);

                    if (!occupiedTiles.Contains(gridPos))
                    {
                        occupiedTiles.Add(gridPos);

                        Instantiate(checkPointMarker, gridPos + new Vector3(0, 0.5f, 0), transform.rotation);
                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

        RaycastHit hit = RAY();
        GetPlaceMarkerGridPos(hit);

        if (Input.GetMouseButtonDown(0))
        {
            upgrade = false;
            PlaceMarker(hit);
        }
        if (Input.GetMouseButtonDown(1))
        {
            upgrade = true;
            PlaceMarker(hit);
        }
        
    }
    void GetPlaceMarkerGridPos(RaycastHit hit)
    {
        Vector3 location = hit.point;

        placeMarker.transform.position = GetGridLockedPos(location);
    }
    Vector3 GetGridLockedPos(Vector3 location)
    {
        Vector3 gridLockedPos = new Vector3(
            Mathf.Round(location.x / gridSize) * gridSize,
            gameObject.transform.position.y,
            Mathf.Round(location.z / gridSize) * gridSize
        );
        return gridLockedPos;
    }
    void PlaceMarker(RaycastHit hit)
    {
        Vector3 placementPos = placeMarker.transform.position;

        if(!occupiedTiles.Contains(placementPos) && !upgrade)
        {
            defence currentDefence = objectToPlace.GetComponent<defence>();
            if (Manager.resources >= currentDefence.price)
            {
                Instantiate(objectToPlace, placementPos, Quaternion.identity);

                occupiedTiles.Add(placementPos);
                Manager.resources -= currentDefence.price;
            }
           
        }
        else
        {
            
            GameObject thattile = hit.collider.gameObject;
            //check op tags zodat hij niet andere gameobjects verwijdert
            if (thattile.tag == "defence")
            {
                
                defence deletingTile = thattile.GetComponent<defence>();
                if (upgrade && deletingTile.canUpgrade)
                {
                    if (Manager.resources >= deletingTile.upgradecost)
                    {
                        Manager.resources -= deletingTile.upgradecost;
                        deletingTile.Upgrade();
                    }
                    else
                    {
                        Debug.Log("not enough resources for upgrade");
                    }
                }
                else if (!upgrade)
                {
                    occupiedTiles.Remove(thattile.transform.position);
                    Destroy(thattile);
                    Manager.resources += deletingTile.sellPrice;
                }



            }
        }
    }
    RaycastHit RAY()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);
        return hit;
    }
   
}
