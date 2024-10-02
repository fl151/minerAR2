using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CounterOpenedCells
{
    private int _countOpenedMines = 0;
    private int _maxCount;

    public int CountOpenedMines => _countOpenedMines;

    public event UnityAction Finished;

    public CounterOpenedCells(int maxCount)
    {
        _maxCount = maxCount;
    }

    public void OpenCell()
    {
        _countOpenedMines++;

        if (_countOpenedMines == _maxCount)
            Finished?.Invoke();
    }
}
