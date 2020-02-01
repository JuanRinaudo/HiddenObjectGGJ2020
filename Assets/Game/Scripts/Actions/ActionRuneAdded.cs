using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRuneAdded : AbstractAction
{

    public override void PlayAction()
    {
        Game.the.RuneAdded();
    }

}
