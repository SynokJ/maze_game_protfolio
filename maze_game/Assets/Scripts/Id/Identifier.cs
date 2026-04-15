using Unity.VisualScripting;
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

    public static bool operator ==(Identifier idA, Identifier idB)
    {
        if (idA.IsUnityNull() || idA.identity.IsUnityNull())
        {
            Debug.Log($"idA is missing components: {idA.IsUnityNull()} || {idA?.identity.IsUnityNull()}");
            return false;
        }

        if (idB.IsUnityNull() || idB.identity.IsUnityNull())
        {
            Debug.Log($"idB is missing components: {idB.IsUnityNull()} || {idB?.identity.IsUnityNull()}");
            return false;
        }

        return idA.identity.Trim().Equals(idB.identity.Trim());
    }

    public static bool operator !=(Identifier idA, Identifier idB)
        => !(idA == idB);
}
