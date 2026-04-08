using UnityEngine;

public class BombScript : MonoBehaviour
{
    public Vector3 size;
    public Vector3 maxSize;
    public float expansionSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        size = gameObject.transform.localScale;
        if (size.x < maxSize.x)
        {
            
            gameObject.transform.localScale += new Vector3(expansionSpeed, expansionSpeed, expansionSpeed);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
