using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Board : MonoBehaviour
{
    [SerializeField] private CellModel _cellPrefab;
    [SerializeField] private GameResultController _grc;

    [SerializeField] private int _countMines = 10;
    [SerializeField] private int _xSize = 10;
    [SerializeField] private int _ySize = 10;
    [SerializeField] private Vector2 _startPoint;


    private Table _table;
    private CounterOpenedCells _COC;
    private List<Cell> _mineCells;
    private Cell[,] _cells;

    private Queue<CellModel> _deletingCells = new Queue<CellModel>();

    public event UnityAction<CellModel> NewCellModel;
    public event UnityAction<CellModel> DelitingCellModel;

    public int CountMines => _countMines;

    private void Awake()
    {
        CreateBoard();
    }

    private void Start()
    {
        SpawnCells(_cells);
    }

    private void OnEnable()
    {
        FollowEvents();
    }

    private void Update()
    {
        TryDeleteCell();
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

        _grc.Restart();
    }

    private void OnAllCellsOpened()
    {
        _grc.TryWin();
    }

    private void OnMineExpoded()
    {
        _grc.TryLose();

        foreach (var mineCell in _mineCells)
        {
            ((MineCell)mineCell).BOOOM -= OnMineExpoded;
            mineCell.Open();
        } 
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
                NewCellModel?.Invoke(cm);
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

        var tempCells = from s in cells where s.gameObject.activeInHierarchy select s;

        var tempCellsList = tempCells.ToList();

        for (int i = 0; i < tempCellsList.Count; i++)
        {
            var tempCell = tempCellsList[i];
            tempCell.gameObject.SetActive(false);
            _deletingCells.Enqueue(tempCell);
        }
    }

    private void TryDeleteCell()
    {
        if (_deletingCells.Count != 0)
        {
            var deletingCell = _deletingCells.Dequeue();
            DelitingCellModel?.Invoke(deletingCell);
            Destroy(deletingCell.gameObject);
        }
    }
}
