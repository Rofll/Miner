using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreationCommand : BaseCommand
{
    private const string RESOURCE_PATH = "Prefabs/Game/Player/";
    private const string OBJECT_NAME = "Player";

    public override void Execute()
    {
        Object playerObject = GameObject.Find(OBJECT_NAME);

        if (!playerObject)
        {
            playerObject = Resources.Load(RESOURCE_PATH + OBJECT_NAME) as GameObject;

            if (playerObject)
            {
                GameObject clone = Object.Instantiate(playerObject) as GameObject;
                clone.name = OBJECT_NAME;

                Vector2 playerPosition = new Vector2(((GameConfig.Seed + 1) * GameConfig.WorldSize.y / 2 * 100) % GameConfig.WorldSize.x, ((GameConfig.Seed + 1) * GameConfig.WorldSize.x / 3 * 100) % GameConfig.WorldSize.y);

                clone.transform.position = playerPosition;
            }
        }

        else
        {
            Debug.LogError(OBJECT_NAME + " == NULL");
        }
    }
}
