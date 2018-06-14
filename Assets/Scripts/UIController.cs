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

    public GridLayoutGroup slotHolder;
    public Slot slotPrefab;

    public Container playerInventory;
    public Container merchantInventory;

    //For debug. Added/removed using space/backspace
    public Item item;
    public int qty;

    //For redrawing slots. Called from Container add/remove code.
    public List<Slot> activeSlots = new List<Slot>();

    public bool inventoryActive;

    private void Awake()
    {
        playerInventory = new Container(10);
        merchantInventory = new Container(5);
        slotHolder.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryActive = !inventoryActive;
            if (inventoryActive)
                DrawContainer(playerInventory);
            else
                slotHolder.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            inventoryActive = !inventoryActive;
            if (inventoryActive)
                DrawContainer(merchantInventory);
            else
                slotHolder.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            playerInventory.AddItem(item, qty);

        if (Input.GetKeyDown(KeyCode.Backspace))
            playerInventory.RemoveItem(item, qty);
    }

    private void DrawContainer(Container container)
    {
        slotHolder.gameObject.SetActive(true);
        activeSlots.Clear();

        foreach(Transform t in slotHolder.transform)
        {
            Destroy(t.gameObject);
        }

        if (container.slots.Count > 6)
            slotHolder.constraintCount = 6;
        else
            slotHolder.constraintCount = container.slots.Count;

        for(int i = 0;i<container.slots.Count;i++)
        {
            var slot = Instantiate(slotPrefab, slotHolder.transform);
            slot.data = container.slots[i];
            slot.RedrawSlot();
            activeSlots.Add(slot);
        }
    }

}
