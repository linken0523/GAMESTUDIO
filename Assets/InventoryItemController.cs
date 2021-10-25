using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryItemController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject itemObject;
    public InventoryObject inventory;
    public GameObject MainCharactor;
    void Start()
    {
        MainCharactor = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            Console.WriteLine("This is C#");
            dropItem();
        }
    }
    public void dropItem(){
        var item = itemObject.GetComponent<Item>();
        inventory.AddItem(item.item, -1);
        Instantiate(itemObject, MainCharactor.transform.position + Vector3.up, MainCharactor.transform.rotation);

    }
}
