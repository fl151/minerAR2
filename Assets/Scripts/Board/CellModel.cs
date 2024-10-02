using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CellModel : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private TMP_Text _text;

    private Cell _cell;

    public void Init(Cell cell)
    {
        _cell = cell;
        _platform.Init(cell);
        SetView();
    }

    private void SetView()
    {
        if (_cell is MineCell)
        {
            _text.text = "*";
        }
        else if (_cell is NumberCell)
        {
            _text.text = ((NumberCell)_cell).CountMinesAround.ToString();
        }
        else
        {
            _text.text = "";
        }
    }
}
