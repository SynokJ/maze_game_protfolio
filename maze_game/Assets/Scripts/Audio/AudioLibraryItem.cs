using UnityEngine;

[System.Serializable]
public class AudioLibraryItem
{
    public string ItemName => itemName;
    public Identifier Identifier => identifier;
    public AudioClip ItemAudioClip => itemAudioClip;

    [Header("Audio Item Components:")]
    [SerializeField] protected string itemName = default;
    [SerializeField] protected AudioClip itemAudioClip = null;
    [SerializeField] protected Identifier identifier = default;
}
