using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionWorldScale : AbstractAction
{

    public GameObject target;
    public Vector3 to = new Vector3(1, 1, 1);
    public float time = 1f;
    public LeanTweenType easeCurve = LeanTweenType.linear;

    public override void PlayAction()
    {
        if (target == null) { target = gameObject; }
        LeanTween.scale(target, to, time).setEase(easeCurve);
    }

}
