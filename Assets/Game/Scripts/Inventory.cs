using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public InventorySlot[] slots;

    public void AddItem(KeyItem item, int forcedSlot = -1)
    {
        int slot = forcedSlot != -1 ? forcedSlot : GetEmptySlotIndex();

        if (slot != -1)
        {
            slots[slot].SetItem(item);
        }
        else
        {
            // NOTE(Juan): Inventory full. Do something?
        }
    }

    private int GetEmptySlotIndex()
    {
        for(int slotIndex = 0; slotIndex < slots.Length; ++slotIndex)
        {
            if(slots[slotIndex].item == null) { return slotIndex; }
        }

        return -1;
    }

}
