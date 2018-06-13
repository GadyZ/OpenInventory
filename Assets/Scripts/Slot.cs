using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour {
    public Item itemInSlot;
    public int currentStack = 0;

    public Image icon;
    public Text text;

    private void Start()
    {
        RedrawSlot();
    }

    public void RedrawSlot()
    {
        if(itemInSlot != null)
        {
            icon.enabled = true;
            icon.sprite = itemInSlot.icon;
            text.text = itemInSlot.name + " " + currentStack + "/" + itemInSlot.maxStack;
        }
        else
        {
            icon.enabled = false;
            text.text = "";
        }
    }
}
