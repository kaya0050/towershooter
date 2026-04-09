using UnityEngine;

public class effectscript : MonoBehaviour
{
    public int timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer--;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
