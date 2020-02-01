using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDelay : AbstractAction
{

    public float delayTime = 1;
    public AbstractAction[] actions;

    public override void PlayAction()
    {
        LeanTween.delayedCall(delayTime, DoDelayedInteractions);
    }

    private void DoDelayedInteractions()
    {
        for (int actionIndex = 0; actionIndex < actions.Length; ++actionIndex)
        {
            actions[actionIndex].PlayAction();
        }
    }

}
