using System.Collections.Generic;
using UnityEngine;

public abstract class ModelView : MonoBehaviour, IActivatable, IDeactivatable
{
    [SerializeField] private List<GameObject> _prefabs;

    private List<GameObject> _models = new List<GameObject>();

    private int _currentModelIndex = 0;

    protected int CountModels => _models.Count;

    public void Init()
    {
        foreach (var prefab in _prefabs)
            InitModel(prefab);
    }

    protected void ActivateFirstModel()
    {
        ActivateModel(_currentModelIndex);
    }

    protected void ActivateNextModel()
    {
        DeactivateModel(_currentModelIndex);

        _currentModelIndex = GetNextIndex(_currentModelIndex);

        ActivateModel(_currentModelIndex);
    }

    protected void DeactivateModels()
    {
        foreach (var model in _models)
            model.SetActive(false);
    }

    private void DeactivateModel(int index)
    {
        _models[index].SetActive(false);
    }

    private void ActivateModel(int index)
    {
        _models[index].SetActive(true);
    }

    private int GetNextIndex(int currentIndex)
    {
        if(currentIndex == _models.Count - 1)
            currentIndex = 0;
        else
            currentIndex += 1;

        return currentIndex;
    }

    private void InitModel(GameObject prefab)
    {
        var model = Instantiate(prefab, gameObject.transform);
        model.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        model.transform.Rotate(new Vector3(-90, 180, 0), Space.Self);
        model.transform.localPosition = new Vector3(0, 0, -0.489f);

        model.SetActive(false);

        _models.Add(model);
    }

    public abstract void Activate();

    public abstract void Deactivate();
}
