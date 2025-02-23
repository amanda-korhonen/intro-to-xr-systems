using UnityEngine;
using UnityEngine.InputSystem;

public class BreakOut : MonoBehaviour
{
    public Transform originalPlace;
    public Transform externalPlace;
    private bool isExternalPlace = false;
    public InputActionReference action;
    void Start()
    {
        action.action.Enable();
        action.action.performed += SwitchPosition;
    }

    private void SwitchPosition(InputAction.CallbackContext context)
    {
        if(isExternalPlace) 
        {
            // if true go to original room 
            transform.position = originalPlace.position;
            transform.rotation = originalPlace.rotation;
        }
        else 
        {
            // if false go to the external place
            transform.position = externalPlace.position;
            transform.rotation = externalPlace.rotation;
        }
        // toggle between the views
        isExternalPlace = !isExternalPlace;
    }
}
