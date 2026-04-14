using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneAsyncTransition : AbstractActionButton
{
    [Header("Scene Name:")]
    [SerializeField] protected string sceneName;
    
    protected override void OnClick()
        => StartCoroutine(LoadSceneWithDelay());

    protected IEnumerator LoadSceneWithDelay()
    {
        AsyncOperation tempTask = SceneManager.LoadSceneAsync(sceneName);

        while (!tempTask.isDone)
        {
            Debug.Log($"<color=orange>Async Continue => {tempTask.progress}</color>");
            yield return null;
        }
    }
}