using UnityEngine;
using UnityEngine.Tilemaps;

public class GameLevelView : MonoBehaviour
{
    [Header("Components:")]
    [SerializeField] protected GameLevelModel model = default;
    [SerializeField] protected GameLevelController controller = null;

    [Space, Header("Tilemaps:")]
    [SerializeField] protected Tilemap groundTilemap;
    [SerializeField] protected Tilemap wallTilemap;

    protected virtual void OnEnable()
        => controller.OnMazeCalculated += OnMazeCalculated;

    protected virtual void OnDisable()
       => controller.OnMazeCalculated -= OnMazeCalculated;

    protected virtual void OnMazeCalculated(LevelCell[,] maze)
    {
        groundTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();

        for (int x = 0; x < model.LevelWidth; x++)
        {
            for (int y = 0; y < model.LevelHeight; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0) - new Vector3Int(model.LevelWidth, model.LevelHeight, 0) / 2;

                if (maze[x, y].State == LevelCellState.Wall)
                    wallTilemap.SetTile(cellPos, model.WallTile);
                else
                    groundTilemap.SetTile(cellPos, model.GroundTile);
            }
        }
    }
}
