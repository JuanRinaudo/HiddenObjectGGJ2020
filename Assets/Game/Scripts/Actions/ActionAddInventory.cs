using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAddInventory : AbstractAction
{

    public KeyItem keyItem;
    public Inventory inventory;

    public override void PlayAction()
    {
        inventory.AddItem(keyItem);
    }

}
