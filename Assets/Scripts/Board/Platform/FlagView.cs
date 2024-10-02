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
        FlagAction();
    }

    private void OnDisable()
    {
        _platform.FlagAction -= FlagAction;
    }

    private void FlagAction()
    {
        _flag.SetActive(_platform.IsFlaged);
    }
}
