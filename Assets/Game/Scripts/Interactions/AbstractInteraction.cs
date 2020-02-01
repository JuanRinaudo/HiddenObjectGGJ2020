using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteraction : MonoBehaviour
{

    public int interactionCount = -1;
    public AbstractAction[] actions;

    public void DoInteractions()
    {
        if(interactionCount == -1 || interactionCount > 0)
        {
            for(int actionIndex = 0; actionIndex < actions.Length; ++actionIndex)
            {
                actions[actionIndex].PlayAction();
            }
            --interactionCount;
        }
    }

}
