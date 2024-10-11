using UnityEngine;

public class PlayerModelStateMachine : MonoBehaviour
{
    [SerializeField] private FlagButton _flagButton;
    [Space]
    [SerializeField] private PlayerModelView _player;
    [SerializeField] private FlagModelView _flag;

    private void OnEnable()
    {
        _flagButton.OnClicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _flagButton.OnClicked -= OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        if (_flagButton.IsActive)
        {
            _player.Deactivate();
            _flag.Activate();
        }
        else
        {
            _flag.Deactivate();
            _player.Activate();
        }
    }
}
