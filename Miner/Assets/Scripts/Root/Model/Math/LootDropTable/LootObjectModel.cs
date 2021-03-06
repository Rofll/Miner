﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketObjectModel <TObjectType> where TObjectType : System.Enum
{
    public BucketObjectModel(TObjectType item, float weight, int count)
    {
        this.item = item;
        this.weight = weight;
        this.count = count;
    }

    private readonly TObjectType item;
    private readonly float weight;
    private int count;

    public TObjectType Item
    {
        get { return item; }
    }

    public float Weight
    {
        get { return weight; }
    }

    public int Count
    {
        get { return count; }
    }

    public void DecreaseCount( int count)
    {
        this.count -= count;
    }
}
