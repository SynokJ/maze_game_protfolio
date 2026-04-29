using System;
using UnityEngine;

[System.Serializable]
public class LevelCell : ICloneable
{
    public int Size => size;
    public LevelCellState State => state;
    public Vector2Int Position => position;

    [SerializeField, Min(1)] protected int size = 1;
    [SerializeField, Min(0)] protected LevelCellState state = 0;
    [SerializeField] protected Vector2Int position = Vector2Int.zero;

    public LevelCell(LevelCellState state)
        => this.state = state;

    public LevelCell(int size, LevelCellState state)
    {
        this.state = state;
        this.size = size;
    }

    public virtual void UpdateState(LevelCellState state)
        => this.state = state;

    public virtual void UpdatePosition(Vector2Int position)
        => this.position = position;

    public object Clone()
        => this.MemberwiseClone();
}

public enum LevelCellState
{
    Ground = 0,
    Wall = 1
}