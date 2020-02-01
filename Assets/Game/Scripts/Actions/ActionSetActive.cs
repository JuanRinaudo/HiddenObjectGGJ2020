using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSetActive : AbstractAction
{

    public GameObject target;
    public bool state = true;

    public override void PlayAction()
    {
        if(target == null) { target = gameObject; }
        target.SetActive(state);
    }

}
