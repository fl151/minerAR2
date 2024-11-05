using UnityEngine;

public class CanvasChanger : MonoBehaviour
{
    [SerializeField] private GameObject _canvas1;
    [SerializeField] private GameObject _canvas2;

    private void Start()
    {
        _canvas1.SetActive(true);
        _canvas2.SetActive(false);
    }

    public void Change()
    {
        _canvas1.SetActive(!_canvas1.activeSelf);
        _canvas2.SetActive(!_canvas2.activeSelf);
    }
}

