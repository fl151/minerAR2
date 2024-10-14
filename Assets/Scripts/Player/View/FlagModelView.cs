using UnityEngine;

public class FlagModelView : ModelView
{
    private bool _isActive = false;

    private const float _animDelaySec = 0.15f;

    private float _timer = 0;

    public override void Activate()
    {
        ActivateFirstModel();
        _isActive = true;
    }

    public override void Deactivate()
    {
        _isActive = false;
        DeactivateModels();
    }

    private void Update()
    {
        if (_isActive)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                ActivateNextModel();
                _timer = _animDelaySec;
            }
        }
    }
}
