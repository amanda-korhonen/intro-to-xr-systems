using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    [SerializeField] private Animator dummyAnimator;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            dummyAnimator.SetTrigger("Death");
        }
    }
    public void ActivateDummy() 
    {
        dummyAnimator.SetTrigger("Activate");
    }
}
