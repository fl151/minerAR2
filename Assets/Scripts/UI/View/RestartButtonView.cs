using UnityEngine;
using UnityEngine.UI;

public class RestartButtonView : MonoBehaviour
{
    [SerializeField] private GameResultController _grc;
    [SerializeField] private Sprite _default;
    [SerializeField] private Sprite _win;
    [SerializeField] private Image _image;

    private void OnEnable()
    {
        _grc.Win += OnWin;
        _grc.Restarted += OnRestarted;
    }

    private void Start()
    {
        SetImage(_default);
    }

    private void OnDisable()
    {
        _grc.Win -= OnWin;
        _grc.Restarted -= OnRestarted;
    }

    private void OnWin()
    {
        SetImage(_win);
    }

    private void OnRestarted()
    {
        SetImage(_default);
    }

    private void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
