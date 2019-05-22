using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceCreateModel
{
    public ResourceCreateModel()
    {

    }

    public ResourceCreateModel(ResourceTypesEnum type, float weight, int count)
    {
        this.type = type;
        this.weight = weight;
        this.count = count;
    }

    [SerializeField]
    private ResourceTypesEnum type;

    [SerializeField]
    [Range(1,float.MaxValue)]
    private float weight;

    [SerializeField]
    [Range(0, 100000)]
    private int count;

    public ResourceTypesEnum Type
    {
        get { return type; }
    }

    public float Weight
    {
        get { return weight; }
    }

    public int Count
    {
        get { return count; }
    }
}
