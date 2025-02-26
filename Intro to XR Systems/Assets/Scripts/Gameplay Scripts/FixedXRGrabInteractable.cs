using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FixedXRGrabInteractable : XRGrabInteractable
{
    [SerializeField] private Transform leftHandAttachTransform;
    [SerializeField] private Transform rightHandAttachTransform;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("Left Hand"))
        {
            attachTransform = leftHandAttachTransform;
        }

        if (args.interactableObject.transform.CompareTag("Right Hand"))
        {
            attachTransform = rightHandAttachTransform;
        }
        base.OnSelectEntered(args);
    }
}
