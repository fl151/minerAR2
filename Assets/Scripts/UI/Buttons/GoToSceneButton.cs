using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneButton : DefaultButton
{
    [SerializeField] private int _sceneIndex;

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(_sceneIndex);

        base.OnButtonClick();
    }
}
