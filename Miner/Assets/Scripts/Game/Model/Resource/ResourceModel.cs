﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceModel
{
    public ResourceModel(ResourceTypesEnum resourceType, int resourceCount)
    {
        this.resourceType = resourceType;
        this.resourceCount = resourceCount;
    }

    private readonly ResourceTypesEnum resourceType;
    private int resourceCount = 0;

    public ResourceTypesEnum ResourceType
    {
        get { return resourceType; }
    }

    public int ResourceCount
    {
        get { return resourceCount; }
    }

    public void AddResource(int count)
    {
        resourceCount += count;
    }

    public override string ToString()
    {
        return String.Format("ResourceType: {0}, ResourceCount: {1}", resourceType, resourceCount);
    }
}