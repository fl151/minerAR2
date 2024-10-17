using TMPro;
using UnityEngine;

public class CounterMines : MonoBehaviour
{
    [SerializeField] private GameResultController _grc;
    [SerializeField] private Board _board;
    [SerializeField] private TMP_Text _text;

    private int _countFlags = -1;

    private void OnEnable()
    {
        _board.NewCellModel += OnNewCellModel;
        _board.DelitingCellModel += OnDeletingCellModel;

        _grc.Restarted += OnGameRestarted;
    }

    private void Start()
    {
        OnFlagAction(true);
    }

    private void OnDisable()
    {
        _board.NewCellModel -= OnNewCellModel;
        _board.DelitingCellModel -= OnDeletingCellModel;
        _grc.Restarted -= OnGameRestarted;
    }

    private void OnNewCellModel(CellModel cm)
    {
        cm.Platform.FlagAction += OnFlagAction;
    }

    private void OnDeletingCellModel(CellModel cm)
    {
        cm.Platform.FlagAction -= OnFlagAction;
    }

    private void OnFlagAction(bool isFlaged)
    {
        if (isFlaged)
            _countFlags++;
        else
            _countFlags--;

        SetCountText(_countFlags);
    }

    private void OnGameRestarted()
    {
        _countFlags = -1;
        OnFlagAction(true);
    }

    private void SetCountText(int count)
    {
        _text.text = count.ToString() + "/" + _board.CountMines.ToString();
    }
}
