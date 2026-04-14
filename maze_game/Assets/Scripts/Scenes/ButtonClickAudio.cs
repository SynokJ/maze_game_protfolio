using System.Linq;
using UnityEngine;

public class ButtonClickAudio : AbstractActionButton
{
    [SerializeField] protected AudioSource audioSource = null;
    [SerializeField] protected Identifier identifyer = default;
    [SerializeField] protected AudioLibraryModel libraryModel = null;

    protected AudioLibraryItem currentLibraryitem = default;

    protected override void OnClick()
    {
        currentLibraryitem = libraryModel.ItemsLibraryContainer.FirstOrDefault(i => i.Identifier.Identity.Trim().Equals(identifyer.Identity.Trim()));
        if (currentLibraryitem != null) audioSource.PlayOneShot(currentLibraryitem.ItemAudioClip);
    }
}
