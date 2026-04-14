using UnityEngine;

public class ButtonClickAudio : AbstractActionButton
{
    [SerializeField] protected AudioClip audioClip;

    protected override void OnClick()
    {
        Debug.Log("<color=yellow>Button Click Sound</color>");
    }
}
