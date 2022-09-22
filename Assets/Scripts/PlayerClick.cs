using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;



public class PlayerClick : MonoBehaviour // På Playeren
{
    public Material[] materials;
    public Renderer[] screens;
    public Camera[] cameras;
    public List<Camera> enabledCameras = new List<Camera>();
    public Queue<Camera> queueofEnabledCameras = new Queue<Camera>();
    public Light[] screenLights;
    Ray ray;
    //public GameObject door;



    DoorController doorController;

    private void Awake()
    {
        foreach (Camera cam in cameras)
        {
            cam.enabled = false;
        }
    }

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

        switch (hit.collider.gameObject.name)
        {
            case "KnapS1K1":
                TurnSelectedCamerasOnAndDisableTheRest(0,0,1);
                break;

            case "KnapS1K2":
                TurnSelectedCamerasOnAndDisableTheRest(1, 0, 2);
                break;

            case "KnapS1K3":
                TurnSelectedCamerasOnAndDisableTheRest(2, 0, 3);
                break;

            case "KnapS1K4":
                TurnSelectedCamerasOnAndDisableTheRest(3, 0, 4);
                break;

            case "KnapS1K5":
                TurnSelectedCamerasOnAndDisableTheRest(4, 0, 5);
                break;

            case "KnapS1K6":
                TurnSelectedCamerasOnAndDisableTheRest(5, 0, 6);
                break;

            case "KnapS1K7":
                TurnSelectedCamerasOnAndDisableTheRest(6, 0, 7);
                break;

            case "KnapS1K8":
                TurnSelectedCamerasOnAndDisableTheRest(7, 0, 8);
                break;

            case "KnapS1K9":
                TurnSelectedCamerasOnAndDisableTheRest(8, 0, 9);
                break;

            case "KnapS1K10":
                TurnSelectedCamerasOnAndDisableTheRest(9, 0, 10);
                break;

            case "KnapS1K11":
                TurnSelectedCamerasOnAndDisableTheRest(10, 0, 11);
                break;

            case "KnapS2K1":
                TurnSelectedCamerasOnAndDisableTheRest(0, 1, 1);
                break;

            case "KnapS2K2":
                TurnSelectedCamerasOnAndDisableTheRest(1, 1, 2);
                break;

            case "KnapS2K3":
                TurnSelectedCamerasOnAndDisableTheRest(2, 1, 3);
                break;

            case "KnapS2K4":
                TurnSelectedCamerasOnAndDisableTheRest(3, 1, 4);
                break;

            case "KnapS2K5":
                TurnSelectedCamerasOnAndDisableTheRest(4, 1, 5);
                break;

            case "KnapS2K6":
                TurnSelectedCamerasOnAndDisableTheRest(5, 1, 6);
                break;

            case "KnapS2K7":
                TurnSelectedCamerasOnAndDisableTheRest(6, 1, 7);
                break;

            case "KnapS2K8":
                TurnSelectedCamerasOnAndDisableTheRest(7, 1, 8);
                break;

            case "KnapS2K9":
                TurnSelectedCamerasOnAndDisableTheRest(8, 1, 9);
                break;

            case "KnapS2K10":
                TurnSelectedCamerasOnAndDisableTheRest(9, 1, 10);
                break;

            case "KnapS2K11":
                TurnSelectedCamerasOnAndDisableTheRest(10, 1, 11);
                break;

            case "KnapS3K1":
                TurnSelectedCamerasOnAndDisableTheRest(0, 2, 1);
                break;

            case "KnapS3K2":
                TurnSelectedCamerasOnAndDisableTheRest(1, 2, 2);
                break;

            case "KnapS3K3":
                TurnSelectedCamerasOnAndDisableTheRest(2, 2, 3);
                break;

            case "KnapS3K4":
                TurnSelectedCamerasOnAndDisableTheRest(3, 2, 4);
                break;

            case "KnapS3K5":
                TurnSelectedCamerasOnAndDisableTheRest(4, 2, 5);
                break;

            case "KnapS3K6":
                TurnSelectedCamerasOnAndDisableTheRest(5, 2, 6);
                break;

            case "KnapS3K7":
                TurnSelectedCamerasOnAndDisableTheRest(6, 2, 7);
                break;

            case "KnapS3K8":
                TurnSelectedCamerasOnAndDisableTheRest(7, 2, 8);
                break;

            case "KnapS3K9":
                TurnSelectedCamerasOnAndDisableTheRest(8, 2, 9);
                break;

            case "KnapS3K10":
                TurnSelectedCamerasOnAndDisableTheRest(9, 2, 10);
                break;

            case "KnapS3K11":
                TurnSelectedCamerasOnAndDisableTheRest(10, 2, 11);
                break;

            case "KnapS1Sluk":
                TurnSelectedCamerasOnAndDisableTheRest(-1, 0, 0);
                break;

            case "KnapS2Sluk":
                TurnSelectedCamerasOnAndDisableTheRest(-1, 1, 0);
                break;

            case "KnapS3Sluk":
                TurnSelectedCamerasOnAndDisableTheRest(-1, 2, 0);
                break;

            default:
                break;
        }

    }

    //Needs to let screens remember which camera they are showing to fix issue

    void TurnSelectedCamerasOnAndDisableTheRest(int camera, int screen, int mat) // Takes the camera, screen and material and turns off all unused cameras.
    {
        if (camera == -1)   //for turning off screens
        {
            screens[screen].material.CopyPropertiesFromMaterial(materials[mat]);
            screenLights[screen].enabled = false;
            return;
        }

        //enabledCameras.Add(cameras[camera]);
        queueofEnabledCameras.Enqueue(cameras[camera]);

        if (queueofEnabledCameras.Count > screens.Length)
        {
           
            queueofEnabledCameras.Peek().enabled = false;
            queueofEnabledCameras.Dequeue();
        }

        cameras[camera].enabled = true;

        

        screenLights[screen].enabled = true;
        screens[screen].material.CopyPropertiesFromMaterial(materials[mat]);
    }

    void TurnSelectedCamerasOnAndDisableTheRestTest(int camera, int screen, int mat) // Takes the camera, screen and material and turns off all unused cameras.
    {
        switch (screen)
        {
            case 0:

                break;

            case 1:

                break;

            case 2:

                break;

        }
    }
}