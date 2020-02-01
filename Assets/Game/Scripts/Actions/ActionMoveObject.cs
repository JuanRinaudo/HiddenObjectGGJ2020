using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMoveObject : AbstractAction
{

    public Transform to;
    public float time = 1f;
    public LeanTweenType easeCurve = LeanTweenType.linear;

    public override void PlayAction()
    {
        LeanTween.move(gameObject, to, time).setEase(easeCurve);
    }

}
