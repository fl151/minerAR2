using UnityEngine;

public class BoardRestarter : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private RestartButton _button;

    private void OnEnable()
    {
        _button.OnClicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _button.OnClicked -= OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        _board.Restart();
    }


}
