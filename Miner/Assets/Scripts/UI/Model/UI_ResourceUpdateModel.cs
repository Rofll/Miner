using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ResourceUpdateModel
{
    public UI_ResourceUpdateModel(ResourceTypesEnum resourceType, int count)
    {
        this.resourceType = resourceType;
        this.count = count;
    }

    private ResourceTypesEnum resourceType;
    private int count;

    public ResourceTypesEnum ResourceType
    {
        get { return resourceType; }
    }

    public int Count
    {
        get { return count; }
    }

}
