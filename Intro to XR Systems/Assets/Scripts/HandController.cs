using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    public InputActionReference gripAction;
    public InputActionReference triggerAction;
    public Hand hand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gripAction.action.Enable();
        triggerAction.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        hand.SetGrip(gripAction.action.ReadValue<float>());
        hand.SetTrigger(triggerAction.action.ReadValue<float>());
    }
}
