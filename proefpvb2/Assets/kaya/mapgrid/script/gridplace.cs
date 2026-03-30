using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class gridplace : MonoBehaviour
{
    public manager Manager;
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
        RaycastHit hit = RAY();
        GetPlaceMarkerGridPos(hit);

        if (Input.GetMouseButtonDown(0))
        {
            PlaceMarker(hit);
        }
    }
    void GetPlaceMarkerGridPos(RaycastHit hit)
    {
        

        Vector3 location = hit.point;

        Vector3 gridLockedPos = new Vector3(
            Mathf.Round(location.x / gridSize) * gridSize,
            gameObject.transform.position.y,
            Mathf.Round(location.z / gridSize) * gridSize
        );

        placeMarker.transform.position = gridLockedPos;
    }

    void PlaceMarker(RaycastHit hit)
    {
        Vector3 placementPos = placeMarker.transform.position;

        if(!occupiedTiles.Contains(placementPos))
        {
            defence currentDefence = objectToPlace.GetComponent<defence>();
            if (Manager.resources > currentDefence.price)
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
                occupiedTiles.Remove(thattile.transform.position);
                Destroy(thattile);
                Manager.resources += deletingTile.sellPrice;

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
