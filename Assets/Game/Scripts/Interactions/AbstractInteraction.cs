using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteraction : MonoBehaviour
{

    public int interactionCount = -1;
    private float lastInteractionCounter = -1;
    public float interactionCooldown = -1;
    public AbstractAction[] actions;

    public void DoInteractions()
    {
        if(lastInteractionCounter <= 0 && (interactionCount <= -1 || interactionCount > 0))
        {
            for(int actionIndex = 0; actionIndex < actions.Length; ++actionIndex)
            {
                actions[actionIndex].PlayAction();
            }
            --interactionCount;
            
            lastInteractionCounter = interactionCooldown;
        }
    }

    private void Update()
    {
        if(interactionCooldown != -1)
        {
            lastInteractionCounter = Mathf.Clamp(lastInteractionCounter - Time.deltaTime, -1, interactionCooldown);
        }
    }

}
