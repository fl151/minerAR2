using UnityEngine;

[RequireComponent(typeof(FlagButtonView))]
public class FlagButton : DefaultButton
{
    private bool _isActive = false;

    public bool IsActive => _isActive;

    protected override void OnButtonClick()
    {
        _isActive = !_isActive;

        base.OnButtonClick();
    }
}
