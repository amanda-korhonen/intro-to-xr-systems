using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{  
    public Light light;
    private Color originalColor;
    private bool lightState = true;
    public InputActionReference action;
    void Start()
    {
        light = GetComponent<Light>();
        originalColor = light.color;

        action.action.Enable();
        action.action.performed += ChangeColor;
    }

    private void ChangeColor(InputAction.CallbackContext context)
    {
        if (lightState) 
        {
            light.color = Color.red;
        }
        else 
        {
            light.color = originalColor;
        }
        // set to true/false depending on the light
        lightState = !lightState; 
    }
}
