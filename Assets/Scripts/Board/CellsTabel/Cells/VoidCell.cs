using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidCell : Cell
{
    private List<Cell> _neighbors;

    public void Init(List<Cell> neighbors)
    {
        _neighbors = neighbors;
    }

    public override void Open()
    {
        if(_isOpen == false)
        {
            base.Open();

            foreach (var neighbor in _neighbors)
            {
                neighbor.Open();
            } 
        }
    }
}
