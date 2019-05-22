using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModel : ObjectModel<TileTypesEnum>
{
    public TileModel(TileTypesEnum tileType, int count = 1)
    {
        this.objectType = tileType;
        this.count = 1;
    }

    public TileModel(List<ResourceModel> resources, TileTypesEnum tileType, int count = 1)
    {
        this.resources = resources;
        this.objectType = tileType;
        this.count = 1;
    }

    public TileModel(List<ResourceModel> resources, TileTypesEnum tileType, Vector2 position, int count = 1)
    {
        this.resources = resources;
        this.objectType = tileType;
        this.position = position;
        this.count = 1;
    }

    private List<ResourceModel> resources;
    private Vector2 position;

    public List<ResourceModel> Resources
    {
        get { return resources; }
    }

    public TileTypesEnum TileType
    {
        get { return objectType; }
    }

    public Vector2 Position
    {
        get { return position; }
    }

    public void InitPosition(Vector2 position)
    {
        this.position = position;
    }

    public void FillResources(List<ResourceModel> resources)
    {
        this.resources = resources;
    }
}
