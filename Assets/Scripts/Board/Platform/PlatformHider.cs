using UnityEngine;

[RequireComponent(typeof(Platform))]
public class PlatformHider : MonoBehaviour
{
    private Platform _platform;

    private void Awake()
    {
        _platform = GetComponent<Platform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>())
            if (FlagInfo.Instance.FlagIsActive)
                _platform.TapFlag();
            else
                if (_platform.IsFlaged == false)
                    HideSelf();
    }

    public void Hide()
    {
        if (_platform.IsFlaged == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void HideSelf()
    {
        _platform.Cell.Open();

        gameObject.SetActive(false);
    }
}
