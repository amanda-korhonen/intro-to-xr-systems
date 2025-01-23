using UnityEngine;

public class OrbitingMoon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform child in transform) 
        {
            child.position += Vector3.up * 10.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
