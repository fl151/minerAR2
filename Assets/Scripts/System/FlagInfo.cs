using UnityEngine;

public class FlagInfo : MonoBehaviour
{
    [SerializeField] private FlagButton _flagButton;

    public bool FlagIsActive => _flagButton.IsActive;

    public static FlagInfo Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
