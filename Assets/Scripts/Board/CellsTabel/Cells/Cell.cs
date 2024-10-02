using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cell
{
    protected bool _isOpen = false;

    public event UnityAction Opened;

    public virtual void Open()
    {
        _isOpen = true;
        Opened?.Invoke();
    }
}
