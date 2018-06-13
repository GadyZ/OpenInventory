using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item",menuName = "New Item")]
public class Item : ScriptableObject {
    public new string name;

    public Sprite icon;

    [Range(1,64)]
    public int maxStack=1;
}
