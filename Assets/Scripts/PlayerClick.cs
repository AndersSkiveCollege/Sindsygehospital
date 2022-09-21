using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;



public class PlayerClick : MonoBehaviour // På Playeren
{
    public Material[] Kamera;
    public Renderer[] Skaerm;

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

        switch (hit.collider.gameObject.name)
        {
            case "KnapS1K1":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[1]);
                break;

            case "KnapS1K2":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[2]);
                break;

            case "KnapS1K3":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[3]);
                break;

            case "KnapS1K4":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[4]);
                break;

            case "KnapS1K5":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[5]);
                break;

            case "KnapS1K6":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[6]);
                break;

            case "KnapS1K7":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[7]);
                break;

            case "KnapS1K8":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[8]);
                break;

            case "KnapS1K9":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[9]);
                break;

            case "KnapS1K10":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[10]);
                break;

            case "KnapS1K11":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[11]);
                break;

            case "KnapS2K1":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[1]);
                break;

            case "KnapS2K2":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[2]);
                break;

            case "KnapS2K3":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[3]);
                break;

            case "KnapS2K4":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[4]);
                break;

            case "KnapS2K5":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[5]);
                break;

            case "KnapS2K6":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[6]);
                break;

            case "KnapS2K7":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[7]);
                break;

            case "KnapS2K8":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[8]);
                break;

            case "KnapS2K9":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[9]);
                break;

            case "KnapS2K10":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[10]);
                break;

            case "KnapS2K11":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[11]);
                break;

            case "KnapS3K1":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[1]);
                break;

            case "KnapS3K2":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[2]);
                break;

            case "KnapS3K3":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[3]);
                break;

            case "KnapS3K4":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[4]);
                break;

            case "KnapS3K5":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[5]);
                break;

            case "KnapS3K6":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[6]);
                break;

            case "KnapS3K7":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[7]);
                break;

            case "KnapS3K8":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[8]);
                break;

            case "KnapS3K9":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[9]);
                break;

            case "KnapS3K10":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[10]);
                break;

            case "KnapS3K11":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[11]);
                break;

            case "KnapS1Sluk":
                Skaerm[0].material.CopyPropertiesFromMaterial(Kamera[0]);
                break;

            case "KnapS2Sluk":
                Skaerm[1].material.CopyPropertiesFromMaterial(Kamera[0]);
                break;

            case "KnapS3Sluk":
                Skaerm[2].material.CopyPropertiesFromMaterial(Kamera[0]);
                break;

            default:
                break;
        }

    }
}