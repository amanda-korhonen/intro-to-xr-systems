using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Transform mainCamera;
    public Transform magnifyingCamera;
    public Transform lens;

    void Update()
    {
        /*//magnifyingCamera.transform.position = lens.position;
        //magnifyingCamera.transform.rotation = mainCamera.rotation;

        // Match lensCamera position to the main camera position
        magnifyingCamera.position = mainCamera.position;

        // Keep the lensCamera forward-facing, regardless of lens rotation
        magnifyingCamera.rotation = Quaternion.LookRotation(mainCamera.forward, Vector3.up);
        */
        Vector3 playerDirection = lens.InverseTransformPoint(mainCamera.position);

        Vector3 viewDirection = lens.TransformPoint(new Vector3(-playerDirection.x,-playerDirection.y,-playerDirection.z));
        magnifyingCamera.transform.LookAt(viewDirection, lens.up);

    }
}
