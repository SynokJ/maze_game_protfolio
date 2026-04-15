using System.Collections;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneAsyncTransition : AbstractActionButton
{
    [Header("Scene Name:")]
    [SerializeField] protected Identifier loadingWindowId = default;
    [SerializeField] protected string sceneName = default;
    [SerializeField] protected WindowManagerController windowManagerController = default;

    protected override void OnClick()
        => StartCoroutine(LoadSceneWithDelay());

    protected IEnumerator LoadSceneWithDelay()
    {
        AsyncOperation tempTask = SceneManager.LoadSceneAsync(sceneName);
        windowManagerController.OpenWindow(loadingWindowId);

        if (windowManagerController.OpenedWindow.IsUnityNull())
        {
            Debug.Log("winC         gg");
            yield break;
        }

        Slider tempSlider = windowManagerController.OpenedWindow.GetComponentInChildren<Slider>();

        if (tempSlider == null)
        {
            Debug.Log("tempSlider gg");
            yield break;
        }

        while (!tempTask.isDone)
        {
            tempSlider.value = tempTask.progress;
            Debug.Log($"<color=orange>Async Continue => {tempTask.progress}</color>");
            yield return null;
        }
    }
}