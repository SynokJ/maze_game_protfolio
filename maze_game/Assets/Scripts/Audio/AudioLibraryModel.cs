using UnityEngine;

[CreateAssetMenu(fileName = nameof(AudioLibraryModel), menuName = "SOs/" + nameof(AudioLibraryModel))]
public class AudioLibraryModel : ScriptableObject
{
    public AudioLibraryItem[] ItemsLibraryContainer => itemsLibraryContainer;

    [SerializeField] protected AudioLibraryItem[] itemsLibraryContainer = default;
}
