using UnityEngine;
using UnityEngine.Rendering;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float fireCoolDown = 0.5f;
    private float lastFireTime;

    void Start()
    {
        lastFireTime = -fireCoolDown;
    }

    public void FireBullet()
    {
        if (Time.time >= lastFireTime + fireCoolDown)
        {
            GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            spawnedBullet.GetComponent<Rigidbody>().linearVelocity = spawnPoint.forward * bulletSpeed;
            Destroy(spawnedBullet, 3f);
            lastFireTime = Time.time;
        }

    }
}
