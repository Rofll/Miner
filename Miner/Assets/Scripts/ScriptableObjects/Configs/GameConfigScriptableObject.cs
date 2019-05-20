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
    private int seed;

    public Vector2 WorldSize
    {
        get { return new Vector2(X,Y); }
    }

    public int Seed
    {
        get { return seed; }
    }
}
