using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigModel
{
    private Vector2 worldSize;
    private int seed;

    public Vector2 WorldSize
    {
        get { return worldSize; }
    }

    public int Seed
    {
        get { return seed; }
    }

    public void Init(Vector2 worldSize, int seed)
    {
        this.worldSize = worldSize;
        this.seed = seed;
    }
}
