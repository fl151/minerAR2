using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class Table
{
    private int _xSize;
    private int _ySize;

    private Cell[,] _cells;
    private List<MineCell> _mineCells = new List<MineCell>();

    private int _countMines;

    public Table(Vector2 startPoint, int countMines = 10, int xSize = 10, int ySize = 10)
    {
        _xSize = Mathf.Clamp(xSize, 0, 25);
        _ySize = Mathf.Clamp(ySize, 0, 25);

        _countMines = Mathf.Clamp(countMines, 0, _xSize* _ySize);

        _cells = new Cell[_xSize, _ySize];

        CreateMines(startPoint);

        AddNumbers();

        AddVoids();

        //ShowCells();
    }

    public Cell[,] GetCells()
    {
        Cell[,] cloneCells = new Cell[_xSize, _ySize];

        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int j = 0; j < _cells.GetLength(1); j++)
            {
                cloneCells[i, j] = _cells[i, j];
            }
        }

        return cloneCells;
    }

    public List<Cell> GetMines()
    {
        var mineCells = new List<Cell>();

        for (int i = 0; i < _mineCells.Count(); i++)
        {
            mineCells.Add(_mineCells[i]);
        }

        return mineCells;
    }

    private void CreateMines(Vector2 startPoint)
    {
        var cellsList = new List<Cell>();

        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int j = 0; j < _cells.GetLength(1); j++)
            {
                if (i != startPoint.x || j != startPoint.y)
                {
                    var cell = new Cell();

                    _cells[i, j] = cell;

                    cellsList.Add(cell);
                }
            }
        }

        Shuffle(cellsList);

        var mineCells = cellsList.Take(_countMines);

        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int j = 0; j < _cells.GetLength(1); j++)
            {
                if (mineCells.Contains(_cells[i, j]))
                {
                    var mine = new MineCell();

                    _cells[i, j] = mine;
                    _mineCells.Add(mine);
                }
            }
        }
    }

    private void AddNumbers()
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int j = 0; j < _cells.GetLength(1); j++)
            {
                if (_cells[i, j] is MineCell == false)
                {
                    int countMinesAround = GetCountMines(i, j);

                    if (countMinesAround > 0)
                    {
                        _cells[i, j] = new NumberCell(countMinesAround);
                    }
                }
            }
        }
    }

    private void AddVoids()
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int j = 0; j < _cells.GetLength(1); j++)
            {
                if (_cells[i, j] is MineCell == false && _cells[i, j] is NumberCell == false)
                {
                    _cells[i, j] = new VoidCell();
                }
            }
        }

        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int j = 0; j < _cells.GetLength(1); j++)
            {
                if (_cells[i, j] is VoidCell)
                {
                    ((VoidCell)_cells[i, j]).Init(GetNeighbors(i, j));
                }
            }
        }
    }

    private void ShowCells()
    {
        string output = "";

        for (int i = 0; i < _cells.GetLength(0); i++)
        {

            for (int j = 0; j < _cells.GetLength(1); j++)
            {
                if (_cells[i, j] is MineCell)
                {
                    output += "*";
                }
                else if (_cells[i, j] is NumberCell)
                {
                    output += ((NumberCell)_cells[i, j]).CountMinesAround.ToString();
                }
                else
                {
                    output += "0";
                }
            }

            output += "\n";
        }

        Debug.Log(output);
    }

    private void Shuffle<T>(IList<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (byte.MaxValue / n)));
            int k = box[0] % n;
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private int GetCountMines(int x, int y)
    {
        int result = 0;

        int minX = 0;
        int maxX = _cells.GetLength(0) - 1;
        int minY = 0;
        int maxY = _cells.GetLength(1) - 1;

        for (int nx = x - 1; nx <= x + 1; nx++)
        {
            for (int ny = y - 1; ny <= y + 1; ny++)
            {
                if (nx >= minX && nx <= maxX && ny >= minY && ny <= maxY && (nx != x || ny != y))
                {
                    if (_cells[nx, ny] is MineCell) result++;
                }
            }
        }

        return result;
    }

    private List<Cell> GetNeighbors(int x, int y)
    {
        List<Cell> neighbors = new List<Cell>();

        int minX = 0;
        int maxX = _cells.GetLength(0) - 1;
        int minY = 0;
        int maxY = _cells.GetLength(1) - 1;

        for (int nx = x - 1; nx <= x + 1; nx++)
        {
            for (int ny = y - 1; ny <= y + 1; ny++)
            {
                if (nx >= minX && nx <= maxX && ny >= minY && ny <= maxY && (nx != x || ny != y))
                {
                    neighbors.Add(_cells[nx, ny]);
                }
            }
        }

        return neighbors;
    }
}
