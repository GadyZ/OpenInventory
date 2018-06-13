using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIController : MonoBehaviour {

    public List<Slot> slots = new List<Slot>();

    public Item item;
    public int qty;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            AddItem(item, qty);

        if (Input.GetKeyDown(KeyCode.Backspace))
            RemoveItem(item, qty);
    }

    public void AddItem(Item item, int qty)
    {
        Debug.Log("Adding " + qty + " " + item.name);
        while(qty > 0)
        {
            if(slots.Exists(x=> (x.itemInSlot == item) && x.currentStack < item.maxStack))
            {
                var targetSlot = slots.First((x => (x.itemInSlot == item) && x.currentStack < item.maxStack));
                var amountToAdd = Mathf.Min(qty, item.maxStack - targetSlot.currentStack);
                targetSlot.currentStack += amountToAdd;
                targetSlot.RedrawSlot();
                qty -= amountToAdd;
            }
            else
            {
                if(slots.Exists(x => x.itemInSlot == null))
                {
                    var targetSlot = slots.First(x => x.itemInSlot == null);
                    targetSlot.itemInSlot = item;
                    targetSlot.currentStack = 0;
                }
                else
                {
                    Debug.Log(qty + " " + item.name + " could not be added");
                    break;
                }
            }
        }

        Debug.Log("Player has " + GetItemCount(item) + " total " + item.name);
    }

    public void RemoveItem(Item item, int qty)
    {
        var itemCount = GetItemCount(item);
        if (itemCount >= qty)
        {
            slots.OrderByDescending(x => x.currentStack);
            while (qty > 0)
            {
                var targetSlot = slots.Last(x => (x.itemInSlot == item) && x.currentStack > 0);
                var amountToRemove = Mathf.Min(qty, targetSlot.currentStack);

                targetSlot.currentStack -= amountToRemove;
                if (targetSlot.currentStack == 0)
                    targetSlot.itemInSlot = null;

                targetSlot.RedrawSlot();
                qty -= amountToRemove;
            }
        }
        else
        {
            Debug.Log("Not enough " + item.name + " exists to remove " + qty+". Has "+itemCount);
        }

        Debug.Log("Player has " + GetItemCount(item) + " total " + item.name);
    }

    public int GetItemCount(Item item)
    {
        return slots.Where(x => x.itemInSlot == item).Sum(x => x.currentStack);
    }
}
