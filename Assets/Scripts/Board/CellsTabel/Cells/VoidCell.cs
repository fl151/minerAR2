using System.Collections.Generic;

public class VoidCell : Cell
{
    private List<Cell> _neighbors;

    public void Init(List<Cell> neighbors)
    {
        _neighbors = neighbors;
    }

    public override void Open()
    {
        if(_isOpen == false && _isFlaged == false)
        {
            base.Open();

            foreach (var neighbor in _neighbors)
            {
                neighbor.Open();
            } 
        }
    }
}
