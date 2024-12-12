using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> itemsList = new();

    public List<Xilo> xilosList = new();

    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void AddItem(Item item)
    {
        itemsList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        itemsList.Remove(item);
    }

    public Item GetItem(Item searchedItem)
    {
        return itemsList.Find((item) => item.Equals(searchedItem));
    }
}
