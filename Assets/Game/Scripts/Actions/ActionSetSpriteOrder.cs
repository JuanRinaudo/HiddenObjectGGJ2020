using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSetSpriteOrder : AbstractAction
{

    public SpriteRenderer sprite;
    public int order;

    public override void PlayAction()
    {
        sprite.sortingOrder = order;
    }

}
