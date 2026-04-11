using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbstractActionButton : MonoBehaviour
{
    protected Button button = default;

    private void OnEnable()
        => button.onClick.AddListener(OnClick);
    
    private void OnDisable()
        => button.onClick.RemoveListener(OnClick);

    protected virtual void Awake()
        => button = GetComponent<Button>();

    protected abstract void OnClick();
}
