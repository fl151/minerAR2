using UnityEngine.Events;

public class MineCell : Cell
{
    public event UnityAction BOOOM;

    public override void Open()
    {
        if (_isOpen == false && _isFlaged == false)
        {
            BOOOM?.Invoke();
            base.Open();
        }
    }
}
