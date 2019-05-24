using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfigInputControlLoadCommand : BaseCommand
{
    private const string RESOURCE_PATH = "Prefabs/Configs/";
    private const string OBJECT_NAME = "InputControlConfig";

    public override void Execute()
    {
        InputControlConfigScriptableObject inputControlConfig = Resources.Load(RESOURCE_PATH + OBJECT_NAME) as InputControlConfigScriptableObject;

        if (inputControlConfig != null)
        {
            InputControlModel.Init(inputControlConfig.Binds);
            Resources.UnloadUnusedAssets();
        }

        else
        {
            Debug.LogError(OBJECT_NAME + " == NULL");
        }
    }
}
