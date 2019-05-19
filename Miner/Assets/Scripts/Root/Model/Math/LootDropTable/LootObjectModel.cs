using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootObjectModel
{
    public LootObjectModel(ResourceTypesEnum item, double weight, int count)
    {
        this.item = item;
        this.weight = weight;
        this.count = count;
    }

    private readonly ResourceTypesEnum item;
    private readonly double weight;
    private int count;

    public ResourceTypesEnum Item
    {
        get { return item; }
    }

    public double Weight
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
