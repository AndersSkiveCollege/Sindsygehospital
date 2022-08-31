using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;



public class PlayerClick : MonoBehaviour // På Playeren
{
    Ray ray;
    //public GameObject door;



    DoorController doorController;



    void Start()
    {
        doorController = GetComponent<DoorController>();
    }



    void OnClick()
    {
        RaycastHit hit;
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Button")
            {
                doorController.ToggleDoor(hit.collider.gameObject.name[6] - '0');
                //door.SetActive(false);
            }
        }
    }
}