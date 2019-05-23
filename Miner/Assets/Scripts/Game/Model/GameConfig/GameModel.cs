using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : IGameModel
{
    private Vector2Int worldSize;
    private uint seed;
    private uint renderWidth;
    private Dictionary<Vector2, TileModel> map;
    private List<TileCreateModel> tiles;


    public Vector2Int WorldSize
    {
        get { return worldSize; }
    }

    public uint Seed
    {
        get { return seed; }
    }

    public uint PlayerWidth
    {
        get { return renderWidth; }
    }

    public Dictionary<Vector2, TileModel> Map
    {
        get { return map; }
    }

    public List<TileCreateModel> Tiles
    {
        get { return tiles; }
    }

    public void Init(Vector2Int worldSize, uint seed, uint renderWidth, List<TileCreateModel> tiles, Dictionary<Vector2, TileModel> map = null)
    {
        this.worldSize = worldSize;
        this.seed = seed;
        this.renderWidth = renderWidth;
        this.tiles = tiles;

        if (map == null)
        {
            this.map = new Dictionary<Vector2, TileModel>();
        }

        else
        {
            this.map = map;
        }
    }

    public void TileAddToMap(TileModel tile)
    {
        map.Add(tile.Position, tile);
    }
}
