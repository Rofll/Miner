using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigModel : IGameConfig
{
    private Vector2Int worldSize;
    private uint seed;
    private uint renderWidth;

    public Vector2Int WorldSize
    {
        get { return worldSize; }
    }

    public uint Seed
    {
        get { return seed; }
    }

    public uint RenderWidth
    {
        get { return renderWidth; }
    }

    public void Init(Vector2Int worldSize, uint seed, uint renderWidth)
    {
        this.worldSize = worldSize;
        this.seed = seed;
        this.renderWidth = renderWidth;
    }
}
