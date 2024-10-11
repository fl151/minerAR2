using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelView : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs;

    protected List<GameObject> _models;

    private void Start()
    {
        foreach (var prefab in _prefabs)
        {
            InitModel(prefab);
        }

        _models[0].SetActive(true);
    }

    protected void ActifateFirstModel()
    {

    }

    protected void ActivateNextModel()
    {

    }

    protected void DeactivateModels()
    {

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
}
