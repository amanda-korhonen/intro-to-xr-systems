using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    // Animation
    public float animationSpeed;
    Animator animator;
    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";

    //Physics Movement
    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform followTarget;
    private Rigidbody body;

    // Colliders
    private Collider handCollider;
    private Collider objectCollider;
    void Start()
    {
        // Animation
        animator = GetComponent<Animator>();

        // Physics Movement
        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        // Teleport hands
        body.position = followTarget.position;
        body.rotation = followTarget.rotation;

        // Get colliders
        handCollider = GetComponent<Collider>();
        objectCollider = followObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();

        PhysicsMove();
    }

    private void PhysicsMove()
    {
        // Position
        var positionWithOffset = followTarget.position + positionOffset;
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        body.linearVelocity = (positionWithOffset - transform.position).normalized 
        * (followSpeed * distance);

        // Rotation
        var rotationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
        if (gripTarget > 0.01f)
        {
            Physics.IgnoreCollision(handCollider, objectCollider, true);
        }
        else 
        {
            Physics.IgnoreCollision(handCollider, objectCollider, false);
        }

    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand() 
    {
        if (gripCurrent != gripTarget) 
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorGripParam, gripCurrent);
            //Debug.Log("Grip: " + gripCurrent);
    
        }

        if (triggerCurrent != triggerTarget) 
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
            //Debug.Log("Trigger: " + triggerCurrent);
        }
    }
}
