using UnityEngine;

public class CellModel : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private CellView _cellView;

    private Cell _cell;

    public void Init(Cell cell)
    {
        _cell = cell;
        _platform.Init(cell);
        _cellView.SetView(_cell);

        _cell.Opened += Open;
    }

    private void OnDisable()
    {
        _cell.Opened -= Open;
    }

    private void Open()
    {
        _cellView.gameObject.SetActive(true);
    }
}
