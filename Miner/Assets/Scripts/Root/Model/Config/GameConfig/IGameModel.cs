using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameModel
{
    Vector2Int WorldSize { get; }

    Dictionary<Vector2, TileModel> Map { get; }

    uint Seed { get; }

    uint PlayerWidth { get; }

    List<TileCreateModel> Tiles { get; }

    void Init(Vector2Int worldSize, uint seed, uint renderWidth, List<TileCreateModel> tiles, Dictionary<Vector2, TileModel> map = null);

    void TileAddToMap(TileModel tile);

    void TileRewriteToMap(TileModel tile);
}
