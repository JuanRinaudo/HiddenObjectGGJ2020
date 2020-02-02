using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDestroy : AbstractAction
{

    public GameObject target;

    public override void PlayAction()
    {
        if(target == null) { target = gameObject; }
        Destroy(gameObject);
    }

}
