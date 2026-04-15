using UnityEngine;

[CreateAssetMenu(fileName = nameof(WindowInstanceModel), menuName = "SOs/Windows/" + nameof(WindowInstanceModel))]
public class WindowInstanceModel : ScriptableObject
{
    public Identifier Identifier => identifier;
    public GameObject WindowPrefab => windowPrefab;

    [SerializeField] protected Identifier identifier = default;
    [SerializeField] protected GameObject windowPrefab = default;
}
