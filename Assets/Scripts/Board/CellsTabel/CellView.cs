using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private Sprite _voidCell;
    [SerializeField] private Sprite _mineCell;

    public void SetView(Cell cell)
    {
        if (cell is MineCell)
        {
            _image.sprite = _mineCell;
        }
        else if (cell is NumberCell)
        {
            _image.sprite = _voidCell;
            _text.gameObject.SetActive(true);
            _text.text = ((NumberCell)cell).CountMinesAround.ToString();
        }
        else if (cell is VoidCell)
        {
            _image.sprite = _voidCell;
        }
        else
        {
            Debug.LogError("Неизвестная клетка!!!");
        }
    }
}
