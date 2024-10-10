using UnityEngine;
using UnityEngine.Events;

public class GameResultController : MonoBehaviour
{
    public event UnityAction Win;
    public event UnityAction Lose;
    public event UnityAction Restarted;

    private bool _isGamePaused = false;

    public static GameResultController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TryWin()
    {
        if(_isGamePaused == false)
        {
            Win?.Invoke();
            _isGamePaused = true;
        }    
    }

    public void TryLose()
    {
        if (_isGamePaused == false)
        {
            Lose?.Invoke();
            _isGamePaused = true;
        }
    }

    public void Restart()
    {
        Restarted?.Invoke();
        _isGamePaused = false;
    }
}
