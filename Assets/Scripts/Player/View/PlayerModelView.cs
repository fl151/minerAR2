using System.Collections;
using UnityEngine;

public class PlayerModelView : ModelView
{
    private bool _isActive = false;

    private float _timer = 0;

    public override void Activate()
    {
        ActivateFirstModel();
        _isActive = true;
    }

    public override void Deactivate()
    {
        _isActive = false;
        StopCoroutine(PlayBlinking());
        DeactivateModels();
    }

    private void Update()
    {
        if (_isActive)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                StartCoroutine(PlayBlinking());

                _timer = Random.Range(1f, 10f);
            }
        }
    }

    private IEnumerator PlayBlinking()
    {
        for (int i = 0; i < CountModels; i++)
        {
            ActivateNextModel();
            yield return new WaitForSeconds(0.05f);
        }
    }

}
