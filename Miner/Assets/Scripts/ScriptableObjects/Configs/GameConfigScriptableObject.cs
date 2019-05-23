using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig", order = 1)]
public class GameConfigScriptableObject : ScriptableObject
{
    [Header("World Size")]

    [SerializeField]
    [Range(50, 500)]
    private int X;

    [SerializeField]
    [Range(50, 5000)]
    private int Y;

    [Header("Seed")]

    [SerializeField]
    private uint seed;

    [Header("WorldSawRadius")]
    [SerializeField]
    private uint playerWidth;
    [SerializeField]
    private uint radarWidth;

    [Header("Tiles")]
    [SerializeField]
    private List<TileCreateModel> tiles = new List<TileCreateModel>();


    public Vector2Int WorldSize
    {
        get { return new Vector2Int(X, Y); }
    }

    public uint Seed
    {
        get { return seed; }
    }

    public uint PlayerWidth
    {
        get { return playerWidth; }
    }

    public List<TileCreateModel> Tiles
    {
        get { return tiles; }
    }
}
