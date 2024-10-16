using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayerModelView : ModelView
{
    public override void Activate()
    {
        ActivateFirstModel();
    }

    public override void Deactivate()
    {
        DeactivateModels();
    }
}
