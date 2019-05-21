﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameModel
{
    Vector2Int WorldSize { get; }

    uint Seed { get; }

    uint RenderWidth { get; }

    void Init(Vector2Int worldSize, uint seed, uint renderWidth, Dictionary<Vector2Int, TileModel> map = null);
}
