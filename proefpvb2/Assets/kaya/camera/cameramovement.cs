using UnityEditor;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    Camera cam;
    public int maxZoom;
    public int minZoom;

    private float mouseZoom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.orthographicSize > maxZoom && cam.orthographicSize < minZoom)
        {
            mouseZoom = Input.mouseScrollDelta.y;
            cam.orthographicSize -= mouseZoom;
        }
        else
        {
            cam.orthographicSize = 15;
        }

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            

            Vector3 pos = transform.position;
            
            pos.x -= mouseX;
            pos.z -= mouseY;
            transform.position = pos;
        }
    }
}
