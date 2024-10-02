using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool _isFlaged = false;
    [SerializeField] private PlatformHider _hider;

    private Cell _cell;

    public Cell Cell => _cell;
    public bool IsFlaged => _isFlaged;

    public event UnityAction FlagAction;

    public void Init(Cell cell)
    {
        _cell = cell;
        _cell.Opened += Hide;
    }

    private void OnDisable()
    {
        _cell.Opened -= Hide;
    }

    public void TapFlag()
    {
        _isFlaged = !_isFlaged;
        FlagAction?.Invoke();
    }

    private void Hide()
    {
        _hider.Hide();
    }
}