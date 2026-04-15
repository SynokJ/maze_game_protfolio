using System.Linq;
using UnityEngine;
using Unity.VisualScripting;

public class WindowManagerController : MonoBehaviour
{
    public GameObject OpenedWindow => openedWindow;

    [SerializeField] protected WindowManagerModel windowManagerModel = default;

    protected GameObject openedWindow = default;
    protected WindowInstanceModel windowInstanceModel = default;

    private void Awake()
        => DontDestroyOnLoad(gameObject);

    public virtual void OpenWindow(Identifier id)
    {
        windowInstanceModel = windowManagerModel.WindowModels.
           FirstOrDefault(i => i.Identifier == id);

        if (windowInstanceModel.IsUnityNull())
        {
            Debug.Log("<color=red> no windows by id </color>");
            return;
        }

        if (openedWindow != null)
            Destroy(openedWindow);

        openedWindow = Instantiate(windowInstanceModel.WindowPrefab);
    }

    public virtual void CloseWindow()
    {
        if (openedWindow != null)
            Destroy(openedWindow);
    }
}
