using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public static UIController instance;
    private void OnEnable()
    {
        if(instance == null)
            instance = this;

        DontDestroyOnLoad(this);
    }

    public Slot emptySlot;
    public GridLayoutGroup slotHolder;  

    public Inventory playerInventory;
    public int playerInventorySlots = 10;

    public Item item;
    public int qty;

    private void Awake()
    {
        playerInventory = new Inventory(playerInventorySlots);

        DrawInventory(playerInventory);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            playerInventory.AddItem(item, qty);

        if (Input.GetKeyDown(KeyCode.Backspace))
            playerInventory.RemoveItem(item, qty);
    }

    void DrawInventory(Inventory inventory)
    {
        foreach (Transform t in slotHolder.transform)
            Destroy(t.gameObject);

        foreach (var x in inventory.slots)
        {
            var newSlot = Instantiate(emptySlot);
            newSlot.transform.SetParent(slotHolder.transform);

            if (x.itemInSlot != null)
            {
                newSlot.itemInSlot = x.itemInSlot;
                newSlot.currentStack = x.currentStack;
            }
            else
            {
                newSlot.itemInSlot = null;
                newSlot.currentStack = 0;
            }

            newSlot.RedrawSlot();
        }
    }
    
}
