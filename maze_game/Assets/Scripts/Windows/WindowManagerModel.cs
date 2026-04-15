using UnityEngine;

[CreateAssetMenu(fileName = nameof(WindowManagerModel), menuName = "SOs/Windows/" + nameof(WindowManagerModel))]
public class WindowManagerModel : ScriptableObject
{
    public WindowInstanceModel[] WindowModels => windowModels;

    [SerializeField] protected WindowInstanceModel[] windowModels = default;
}
