using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MineCell : Cell
{
    public event UnityAction BOOOM;

    public override void Open()
    {
        if (_isOpen == false)
        {
            BOOOM?.Invoke();
            base.Open();
        }
    }
}
