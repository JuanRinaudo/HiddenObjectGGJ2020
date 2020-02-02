using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSetAnimator : AbstractAction
{

    public Animator target;
    public bool state = true;

    public override void PlayAction()
    {
        target.enabled = state;
    }

}
