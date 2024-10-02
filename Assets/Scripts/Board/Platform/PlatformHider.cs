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
        Debug.Log("");

        if (_platform.IsFlaged == false && other.gameObject.GetComponent<Player>())
        {
            _platform.Cell.Open();

            gameObject.SetActive(false);
        }
    }

    public void Hide()
    {
        if (_platform.IsFlaged == false)
        {
            gameObject.SetActive(false);
        }
    }
}
