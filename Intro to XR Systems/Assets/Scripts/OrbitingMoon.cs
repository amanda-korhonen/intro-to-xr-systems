using UnityEngine;

public class OrbitingMoon : MonoBehaviour
{
    public Transform planet;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(planet.transform.position,Vector3.up, 1 * Time.deltaTime);
    }
}
