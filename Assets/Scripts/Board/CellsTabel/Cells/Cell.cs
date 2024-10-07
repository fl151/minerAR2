using UnityEngine.Events;

public class Cell
{
    protected bool _isOpen = false;
    protected bool _isFlaged = false;

    public event UnityAction Opened;

    public virtual void Open()
    {
        if(_isFlaged == false)
        {
            _isOpen = true;
            Opened?.Invoke();
        } 
    }

    public void SetFlag(bool value)
    {
        _isFlaged = value;
    }
}
