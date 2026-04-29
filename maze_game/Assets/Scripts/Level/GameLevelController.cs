using System;
using UnityEngine;
using System.Collections.Generic;

public class GameLevelController : MonoBehaviour
{
    public event Action<LevelCell[,]> OnMazeCalculated = delegate { };

    [Header("Model")]
    [SerializeField] protected GameLevelModel model = default;

    [Header("Seed")]
    [SerializeField] private bool useRandomSeed = true;
    [SerializeField] private int seed = 12345;

    private LevelCell[,] maze;
    private readonly Vector2Int[] directions =
    {
        new Vector2Int(0, 2),
        new Vector2Int(0, -2),
        new Vector2Int(2, 0),
        new Vector2Int(-2, 0)
    };

    private void Start()
    {
        Generate();
    }

    [ContextMenu("Generate Maze")]
    public void Generate()
    {
        if (useRandomSeed)
            seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);

        UnityEngine.Random.InitState(seed);
        maze = new LevelCell[model.LevelWidth, model.LevelHeight];

        for (int x = 0; x < model.LevelWidth; x++)
            for (int y = 0; y < model.LevelHeight; y++)
            {
                maze[x, y] = model.LevelCell.Clone() as LevelCell;
                maze[x, y].UpdatePosition(new Vector2Int(x, y));
                maze[x, y].UpdateState(LevelCellState.Wall);
            }

        CarveMaze();
        CreateEntranceAndExit();
        OnMazeCalculated(maze);
    }

    private void CarveMaze()
    {
        Stack<LevelCell> stack = new Stack<LevelCell>();

        LevelCell startCell = maze[model.LevelStartPos.x, model.LevelStartPos.y];
        startCell.UpdateState(0);
        stack.Push(startCell);

        while (stack.Count > 0)
        {
            Vector2Int current = stack.Peek().Position;
            List<LevelCell> validNeighbors = new List<LevelCell>();

            foreach (var dir in directions)
            {
                Vector2Int next = current + dir;

                if (IsInsideMazeLevel(next) && maze[next.x, next.y].State == LevelCellState.Wall)
                    validNeighbors.Add(maze[next.x, next.y]);
            }

            if (validNeighbors.Count == 0)
            {
                stack.Pop();
                continue;
            }

            LevelCell chosen = validNeighbors[UnityEngine.Random.Range(0, validNeighbors.Count)];

            Vector2Int wall = (current + chosen.Position) / 2;
            maze[wall.x, wall.y].UpdateState(0);
            maze[chosen.Position.x, chosen.Position.y].UpdateState(0);

            stack.Push(chosen);
        }
    }

    private bool IsInsideMazeLevel(Vector2Int pos)
        => pos.x > 0 && pos.x < model.LevelWidth - 1 && pos.y > 0 && pos.y < model.LevelHeight - 1;

    private void CreateEntranceAndExit()
    {
        maze[1, 0].UpdateState(0);                    // Entrance
        maze[model.LevelWidth - 2, model.LevelHeight - 1].UpdateState(0);  // Exit
    }
}
