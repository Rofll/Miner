using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceModel : ObjectModel<ResourceTypesEnum>
{
    public ResourceModel(ResourceTypesEnum resourceType, int resourceCount)
    {
        objectType = resourceType;
        count = resourceCount;
    }

    public override string ToString()
    {
        return String.Format("ResourceType: {0}, ResourceCount: {1}", objectType, count);
    }
}
