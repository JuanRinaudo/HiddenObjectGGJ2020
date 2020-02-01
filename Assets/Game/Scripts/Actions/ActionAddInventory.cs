using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAddInventory : AbstractAction
{

    public KeyItem keyItem;
    public Inventory inventory;

    public int forcedSlot = -1;
    public SoundFX customSound;

    public bool removeOnAction;

    public override void PlayAction()
    {
        inventory.AddItem(keyItem, forcedSlot);

        Sound.the.PlaySound(customSound != null ? customSound : Sound.the.pickupSound);

        if(removeOnAction)
        {
            gameObject.SetActive(false);
        }
    }

}
