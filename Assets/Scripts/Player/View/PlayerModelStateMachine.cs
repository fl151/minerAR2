using UnityEngine;

public class PlayerModelStateMachine : MonoBehaviour
{
    [SerializeField] private FlagButton _flagButton;
    [Space]
    [SerializeField] private PlayerModelView _player;
    [SerializeField] private FlagModelView _flag;

    private ModelView _currentModelView;

    private void Awake()
    {
        _currentModelView = _player;
    }

    private void OnEnable()
    {
        _flagButton.OnClicked += OnButtonClicked;
        _currentModelView.Activate();
    }

    private void OnDisable()
    {
        _flagButton.OnClicked -= OnButtonClicked;
        _currentModelView.Deactivate();
    }

    private void OnButtonClicked()
    {
        if (_flagButton.IsActive)
        {
            _player.Deactivate();
            _flag.Activate();

            _currentModelView = _flag;
        }
        else
        {
            _flag.Deactivate();
            _player.Activate();

            _currentModelView = _player;
        }
    }
}
