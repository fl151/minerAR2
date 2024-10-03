using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FlagButton))]
public class FlagButtonView : MonoBehaviour
{
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    [SerializeField] private Image _image;

    private FlagButton _button;

    private void Awake()
    {
        _button = GetComponent<FlagButton>();
    }

    private void OnEnable()
    {
        _button.OnClicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _button.OnClicked -= OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        if (_button.IsActive)
            _image.sprite = _onSprite;
        else
            _image.sprite = _offSprite;
    }
}
