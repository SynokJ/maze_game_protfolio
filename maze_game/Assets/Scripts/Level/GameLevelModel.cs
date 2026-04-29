using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = nameof(GameLevelModel), menuName = "SOs/GameLevel/" + nameof(GameLevelModel))]
public class GameLevelModel : ScriptableObject
{
    public LevelCell LevelCell => levelCell;
    public int LevelWidth => levelWidth;
    public int LevelHeight => levelHeight;
    public TileBase WallTile => wallTile;
    public TileBase GroundTile => groundTile;
    public Vector2Int LevelStartPos => levelStartPos;

    [Header("Properties")]
    [SerializeField] protected LevelCell levelCell = default;
    [SerializeField, Min(0)] protected int levelWidth = default;
    [SerializeField, Min(0)] protected int levelHeight = default;
    [SerializeField] protected Vector2Int levelStartPos = default;

    [Space, Header("Tiles")]
    [SerializeField] private TileBase groundTile;
    [SerializeField] private TileBase wallTile;

    public override string ToString()
    {
        string res = default;
        res += $"{nameof(levelWidth)} : {levelWidth}\n";
        res += $"{nameof(levelHeight)} : {levelHeight}";
        return res;
    }
}
