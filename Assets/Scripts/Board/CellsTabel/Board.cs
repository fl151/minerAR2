using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private CellModel _cellPrefab;

    private Table _table;
    private CounterOpenedCells _COC;
    private List<Cell> _mineCells;
    private Cell[,] _cells;

    [SerializeField] private int _countMines = 10;
    [SerializeField] private int _xSize = 10;
    [SerializeField] private int _ySize = 10;
    [SerializeField] private Vector2 _startPoint;

    private void Awake()
    {
        CreateBoard();
    }

    private void OnEnable()
    {
        SpawnCells(_cells);
        FollowEvents();
    }

    private void OnDisable()
    {
        UnfollowEvents();
    }

    public void Restart()
    {
        UnfollowEvents();
        RemoveCells();
        CreateBoard();
        SpawnCells(_cells);
        FollowEvents();
    }

    private void OnAllCellsOpened()
    {
        Debug.Log("Win");
    }

    private void OnMineExpoded()
    {
        foreach (var mineCell in _mineCells)
        {
            ((MineCell)mineCell).BOOOM -= OnMineExpoded;
        }

        Debug.Log("BOOM");
    }

    private void OnCellOpened()
    {
        _COC.OpenCell();
    }

    private void SpawnCells(Cell[,] cells)
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                CellModel cm = Instantiate(_cellPrefab,
                                           new Vector3(0, 0, 0),
                                           new Quaternion(), gameObject.transform);
                cm.transform.localPosition = new Vector3((float)i * 0.25f - 0.125f * (cells.GetLength(0) - 0.75f), 0, (float)j * 0.25f - 0.125f * (cells.GetLength(1) - 0.75f));
                cm.Init(cells[i, j]);
            }
        }
    }

    private void CreateBoard()
    {
        _table = new Table(_startPoint, _countMines, _xSize, _ySize);
        _COC = new CounterOpenedCells(_xSize * _ySize - _countMines);
        _cells = _table.GetCells();
        _mineCells = _table.GetMines();
    }

    private void FollowEvents()
    {
        foreach (var mineCell in _mineCells)
        {
            ((MineCell)mineCell).BOOOM += OnMineExpoded;
        }

        foreach (var cell in _cells)
        {
            cell.Opened += OnCellOpened;
        }

        _COC.Finished += OnAllCellsOpened;
    }

    private void UnfollowEvents()
    {
        foreach (var mineCell in _mineCells)
        {
            ((MineCell)mineCell).BOOOM -= OnMineExpoded;
        }

        foreach (var cell in _cells)
        {
            cell.Opened -= OnCellOpened;
        }

        _COC.Finished -= OnAllCellsOpened;
    }

    private void RemoveCells()
    {
        var cells = GetComponentsInChildren<CellModel>();

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            cells[i].gameObject.SetActive(false);
        }
    }
}
