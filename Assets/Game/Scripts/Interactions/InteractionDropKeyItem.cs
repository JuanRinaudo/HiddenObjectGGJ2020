using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDropKeyItem : AbstractInteraction
{

    public KeyItem targetItem;

    private void OnMouseEnter()
    {
        if (InventorySlot.slotBeingDragged != null)
        {
            InventorySlot.slotBeingDragged.CheckInteracteable(this);
        }
    }

    private void OnMouseExit()
    {
        if (InventorySlot.slotBeingDragged != null)
        {
            InventorySlot.slotBeingDragged.UncheckInteracteable(this);
        }
    }

}
