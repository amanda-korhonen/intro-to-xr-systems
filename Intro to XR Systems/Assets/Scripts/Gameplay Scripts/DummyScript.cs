using UnityEngine;

public class DummyScript : MonoBehaviour
{
    [SerializeField] private GameObject[] targetDummies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject dummy in targetDummies)
            {
                //dummies.GetComponent<TargetDummy>().ActivateDummy();
                TargetDummy targetDummy = dummy.GetComponent<TargetDummy>();
                targetDummy.ResetDummy(); // Reset the dummy state
                targetDummy.ActivateDummy(); // Activate the dummy
            }
        }
    }
}
