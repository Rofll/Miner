using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreationCommand : BaseCommand
{
    public override void Execute()
    {
        Debug.LogError("WorldRender");

        int seed = 12;
        Vector2Int world = new Vector2Int(5,5);
        int renderWidth = 1;

        Vector2Int playerPos = new Vector2Int(0,0);

        //bool isWorldUpsideDown = false;

        for (int i = playerPos.y - renderWidth; i <= playerPos.y + renderWidth; i++)
        {
            int posY;

            if (i < 0)
            {
                posY = -i - 1;
            }

            else if (i > world.y)
            {
                posY = world.y - i + 1;
            }

            else
            {
                posY = i;
            }

            for (int j = playerPos.x - renderWidth; j <= playerPos.x + renderWidth; j++)
            {
                int posX;

                if (j < 0)
                {
                    if (i < 0)
                    {
                        posX = world.x / 2 - i + 1;
                    }

                    else
                    {
                        posX = world.x + j + 1;
                    }
                }

                else if (j > world.x)
                {
                    posX = j % world.x - 1;
                }

                else
                {
                    posX = j;
                }

                if (!(posY == playerPos.y && posX == playerPos.x))
                {
                   Debug.LogError(String.Format("Pos:[{0}][{1}]", posX, posY));
                }
            }
        }
    }

    private void BuildWorldPart(int renderWidth)
    {
        for (int i = 0; i < renderWidth; i++)
        {
            
        }
    }
}
