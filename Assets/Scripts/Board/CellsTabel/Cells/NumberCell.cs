public class NumberCell : Cell
{
    private int _countMinesAround = 0;

    public int CountMinesAround => _countMinesAround;

    public NumberCell(int countMinesAround)
    {
        _countMinesAround = countMinesAround;
    }

    public override void Open()
    {
        if(_isOpen == false && _isFlaged == false)
        {
            base.Open();
        } 
    }
}
