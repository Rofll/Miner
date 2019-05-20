using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModel
{
    public TileModel(List<ResourceModel> resources, TileTypesEnum tileType, Vector2 position)
    {
        this.resources = resources;
        this.tileType = tileType;
        this.position = position;
    }

    private readonly List<ResourceModel> resources;
    private readonly TileTypesEnum tileType;
    private readonly Vector2 position;

    public List<ResourceModel> Resources
    {
        get { return resources; }
    }

    public TileTypesEnum TileType
    {
        get { return tileType; }
    }

    public Vector2 Position
    {
        get { return position; }
    }
}
