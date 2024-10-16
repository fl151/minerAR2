using UnityEngine;

public class PlayerModelStateMachine : MonoBehaviour
{
    [SerializeField] private FlagButton _flagButton;
    [Space]
    [SerializeField] private PlayerModelView _player;
    [SerializeField] private FlagModelView _flag;
    [SerializeField] private DeadPlayerModelView _dead;
    [SerializeField] private WinPlayerViewModel _win;

    private ModelView _currentModelView;
    private bool _isGameStoped = false;

    private void Awake()
    {
        _currentModelView = _player;
    }

    private void OnEnable()
    {
        _flagButton.OnClicked += OnButtonClicked;

        GameResultController.Instance.Win += OnWin;
        GameResultController.Instance.Lose += OnLose;
        GameResultController.Instance.Restarted += OnRestart;
        _currentModelView.Activate();
    }

    private void OnDisable()
    {
        GameResultController.Instance.Win -= OnWin;
        GameResultController.Instance.Lose -= OnLose;
        GameResultController.Instance.Restarted -= OnRestart;

        _flagButton.OnClicked -= OnButtonClicked;
        _currentModelView.Deactivate();
    }

    private void OnButtonClicked()
    {
        if(_isGameStoped == false)
        {
            _currentModelView.Deactivate();

            if (_flagButton.IsActive) 
            { 
                _flag.Activate();
                _currentModelView = _flag;
            }
            else
            {
                _player.Activate();
                _currentModelView = _player;
            }
        } 
    }

    private void OnWin()
    {
        OnGameStoped(_win);
    }

    private void OnLose()
    {
        OnGameStoped(_dead);
    }

    private void OnRestart()
    {
        _isGameStoped = false;

        OnButtonClicked();
    }

    private void OnGameStoped(ModelView result)
    {
        _isGameStoped = true;

        _currentModelView.Deactivate();
        result.Activate();

        _currentModelView = result;
    }
}
