using UnityEngine;

public class PlayerModelStateMachine : MonoBehaviour
{
    [SerializeField] private FlagButton _flagButton;
    [SerializeField] private GameResultController _grc;
    [Space]
    [SerializeField] private PlayerModelView _player;
    [SerializeField] private FlagModelView _flag;
    [SerializeField] private DeadPlayerModelView _dead;
    [SerializeField] private WinPlayerViewModel _win;

    private ModelView _currentModelView;
    private bool _isGameStoped = false;

    private void Awake()
    {
        _player.Init();
        _flag.Init();
        _win.Init();
        _dead.Init();

        _currentModelView = _player;
    }

    private void OnEnable()
    {
        _flagButton.OnClicked += OnButtonClicked;

        _grc.Win += OnWin;
        _grc.Lose += OnLose;
        _grc.Restarted += OnRestart;
        _currentModelView.Activate();
    }

    private void OnDisable()
    {
        _grc.Win -= OnWin;
        _grc.Lose -= OnLose;
        _grc.Restarted -= OnRestart;

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
        if(_isGameStoped == false)
        {
            _isGameStoped = true;

            _currentModelView.Deactivate();
            result.Activate();

            _currentModelView = result;
        }
    }
}
