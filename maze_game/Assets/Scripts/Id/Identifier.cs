using UnityEngine;

[CreateAssetMenu(fileName = nameof(Identifier), menuName = "SOs/" + nameof(Identifier))]
public class Identifier : ScriptableObject
{
    /// <summary>
    /// id data
    /// </summary>
    public string Identity => identity;

    [SerializeField] protected string identity = default;

    public override bool Equals(object other)
        => other is Identifier id ? identity.Equals(id.Identity) : false;

    public override int GetHashCode()
        => identity.GetHashCode();
}
