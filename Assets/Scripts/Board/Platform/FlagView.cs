using UnityEngine;

public class FlagView : MonoBehaviour
{
    [SerializeField] private GameObject _flag;
    [SerializeField] private Platform _platform;

    private void OnEnable()
    {
        _platform.FlagAction += FlagAction;
    }

    private void Start()
    {
        FlagAction(false);
    }

    private void OnDisable()
    {
        _platform.FlagAction -= FlagAction;
    }

    private void FlagAction(bool isFlaged)
    {
        _flag.SetActive(isFlaged);
    }
}
