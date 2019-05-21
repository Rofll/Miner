using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigGameLoadCommand : BaseCommand
{
    private const string RESOURCE_PATH = "Prefabs/Configs/";
    private const string OBJECT_NAME = "GameConfig";

    public override void Execute()
    {
        GameConfigScriptableObject gameConfig = Resources.Load(RESOURCE_PATH + OBJECT_NAME) as GameConfigScriptableObject;

        if (gameConfig != null)
        {
            GameConfig.Init(gameConfig.WorldSize, gameConfig.Seed, gameConfig.RenderWidth);
            Resources.UnloadUnusedAssets();
        }

        else
        {
            Debug.LogError(OBJECT_NAME + " == NULL");
        }
    }
}
