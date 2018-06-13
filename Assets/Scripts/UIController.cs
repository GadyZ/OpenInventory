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

    public Container playerInventory;
    public int playerInventorySlots = 10;

    public Item item;
    public int qty;

    private void Awake()
    {
        playerInventory = new Container(10);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            playerInventory.AddItem(item, qty);

        if (Input.GetKeyDown(KeyCode.Backspace))
            playerInventory.RemoveItem(item, qty);
    }

}
