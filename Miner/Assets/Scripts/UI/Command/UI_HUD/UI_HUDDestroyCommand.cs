using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HUDDestroyCommand : BaseCommand
{
    private const string OBJECT_NAME = "UI_HUD";

    public override void Execute()
    {
        GameObject gameObject = GameObject.Find(OBJECT_NAME);

        if (gameObject != null)
        {
            GameObject.Destroy(gameObject);
            Resources.UnloadUnusedAssets();
        }

        else
        {
            Debug.LogError(OBJECT_NAME + " doesn't exist");
        }
    }
}
