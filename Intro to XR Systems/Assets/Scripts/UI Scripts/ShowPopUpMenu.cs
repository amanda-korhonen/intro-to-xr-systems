using System.Data.Common;
using UnityEngine;

public class ShowPopUpMenu : MonoBehaviour
{
    public Transform head;
    public GameObject controlUI;
    public float spawnDistance = 2;
    public GameObject menu;
    public void showPopUpMenu()
    {
        controlUI.SetActive(!controlUI.activeSelf);

        if (controlUI.activeSelf)
        {
            controlUI.transform.position = menu.transform.position +
            new Vector3(head.forward.x,0,head.forward.z).normalized * spawnDistance;

            controlUI.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, 
            head.position.z));
        }
    }
}
