using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private Sprite _sprite1;
    [SerializeField] private Sprite _sprite2;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _image.sprite = _sprite1;

        _coroutine = StartCoroutine(ChangingSprites());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator ChangingSprites()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            _image.sprite = _sprite2;

            yield return new WaitForSeconds(1f);

            _image.sprite = _sprite1;
        }
    }
}
