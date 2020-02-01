using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMoveObject : AbstractAction
{

    public GameObject target;
    public Transform to;
    public float time = 1f;
    public LeanTweenType easeCurve = LeanTweenType.linear;

    public override void PlayAction()
    {
        if (target == null) { target = gameObject; }
        LeanTween.move(target, to, time).setEase(easeCurve);
    }

}
