using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Transform mainCamera;
    public Transform magnifyingCamera;
    public Transform lens;

    void Update()
    {
        Vector3 playerDirection = lens.InverseTransformPoint(mainCamera.position);

        Vector3 viewDirection = lens.TransformPoint(new Vector3(-playerDirection.x,-playerDirection.y,-playerDirection.z));
        magnifyingCamera.transform.LookAt(viewDirection, lens.up);

    }
}
