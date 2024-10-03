using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class DefaultButton : MonoBehaviour
{
    private Button _button;

    public event UnityAction OnClicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    protected virtual void OnButtonClick()
    {
        OnClicked?.Invoke();
    }
}
