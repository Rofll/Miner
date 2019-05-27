using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HUDCreateCommand : BaseCommand
{
    private const string RESOURCE_PATH = "Prefabs/UI/";
    private const string OBJECT_NAME = "UI_HUD";

    public override void Execute()
    {
        GameObject mainCamera = GameObject.Find(OBJECT_NAME);

        if (!mainCamera)
        {
            GameObject mainCameraGameObject = Resources.Load(RESOURCE_PATH + OBJECT_NAME) as GameObject;

            if (mainCameraGameObject)
            {
                GameObject clone = Object.Instantiate(mainCameraGameObject);
                clone.name = OBJECT_NAME;
            }
        }

        else
        {
            Debug.LogError(OBJECT_NAME + " == NULL");
        }
    }
}
