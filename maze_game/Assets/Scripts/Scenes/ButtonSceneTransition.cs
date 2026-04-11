using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneTransition : AbstractActionButton
{
    [Header("Scene Name:")]
    [SerializeField] protected string sceneName;

    protected override void OnClick()
        => SceneManager.LoadScene(sceneName);
}
