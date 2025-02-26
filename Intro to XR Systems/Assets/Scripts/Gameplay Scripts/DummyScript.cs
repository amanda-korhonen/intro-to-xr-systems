using UnityEngine;

public class DummyScript : MonoBehaviour
{
    [SerializeField] private GameObject[] targetDummies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject dummies in targetDummies)
            {
                dummies.GetComponent<TargetDummy>().ActivateDummy();
            }
        }
    }
}
