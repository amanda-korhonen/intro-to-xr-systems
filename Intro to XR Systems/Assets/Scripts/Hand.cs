using System;
using UnityEngine;
using UnityEngine.UIElements;

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
    private Transform followTarget;
    private Rigidbody body;

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
        var distance = Vector3.Distance(followTarget.position, transform.position);
        body.linearVelocity = (followTarget.position - transform.position).normalized 
        * (followSpeed * distance);

        // Rotation
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;

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
    
        }

        if (triggerCurrent != triggerTarget) 
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }
}
