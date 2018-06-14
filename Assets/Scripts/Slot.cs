using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public SlotData data;

    public Image icon;
    public Text text;

    private void Start()
    {
        RedrawSlot();
    }

    public void RedrawSlot()
    {
        if (data.itemInSlot != null)
        {
            icon.enabled = true;
            icon.sprite = data.itemInSlot.icon;
            text.text = data.itemInSlot.name + " " + data.currentStack + "/" + data.itemInSlot.maxStack;
        }
        else
        {
            icon.enabled = false;
            text.text = "";
        }
    }
}