using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileCreateModel
{
    public TileCreateModel()
    {

    }

    public TileCreateModel(TileTypeEnum type, List<ResourceCreateModel> resources, float weight)
    {
        this.type = type;
        this.resources = resources;
        this.weight = weight;
    }

    [SerializeField]
    private TileTypeEnum type;
    [SerializeField]
    [Range(1,float.MaxValue)]
    private float weight;
    [SerializeField]
    private uint minDrop;
    [SerializeField]
    private uint maxDrop;
    [SerializeField]
    private List<ResourceCreateModel> resources;

    public TileTypeEnum Type
    {
        get { return type; }
    }

    public float Weight
    {
        get { return weight; }
    }
    
    public List<ResourceCreateModel> Resources
    {
        get { return resources; }
    }

    public uint MinDrop
    {
        get { return minDrop; }
    }

    public uint MaxDrop
    {
        get { return maxDrop; }
    }
}
