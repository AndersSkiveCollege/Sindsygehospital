using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerHandler : MonoBehaviour
{
    public float power;
    public float powerConsumption;
    public PlayerClick playerClick; // for turning off all the screens
    public List<Light> allLights = new List<Light>(); //all lights with a few exceptions (flashlight)
    private Light[] lights;

    private void Awake()
    {
        
    }

    void Start()
    {
        GetAllLightsInScene();
    }
    
    void Update()
    {
        if (power <= 0)
        {
            PowerOff(); 
        }

        else
        {
            PowerOn();
        }
    }

    void GetAllLightsInScene() 
    {
        lights = FindObjectsOfType(typeof(Light)) as Light[];

        foreach (Light light in lights)
        {
            if (light.name != "FlashLight")
            {
                //stopped working here
            }
        }


    }

    void PowerOff() 
    {
        playerClick.isThereAnyPower = false;
        playerClick.TurnSelectedCamerasOnAndDisableTheRest(-1, 0, 0); //slukker skærmene
        playerClick.TurnSelectedCamerasOnAndDisableTheRest(-1, 1, 0);
        playerClick.TurnSelectedCamerasOnAndDisableTheRest(-1, 2, 0);
    }

    void PowerOn() 
    {
        playerClick.isThereAnyPower = true;
    }
}
