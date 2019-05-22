using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileCreateModel
{
    public TileCreateModel()
    {

    }

    public TileCreateModel(TileTypesEnum type, List<ResourceCreateModel> resources, float weight)
    {
        this.type = type;
        this.resources = resources;
        this.weight = weight;
    }

    [SerializeField]
    private TileTypesEnum type;
    [SerializeField]
    [Range(1,float.MaxValue)]
    private float weight;
    [SerializeField]
    private List<ResourceCreateModel> resources;

    public TileTypesEnum Type
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
}
