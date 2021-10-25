﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount){
        bool hasItem = false;
        for( int i=0; i<Container.Count; i++){
            if(Container[i].item == _item){
                Container[i].addAmount(_amount);
                hasItem = true;
                if(Container[i].amount<=0){
                    Container.RemoveAt(i);
                }
                break;
            }
        }
        if(!hasItem){
            Container.Add(new InventorySlot(_item, _amount));
        }
        
    }

}
[System.Serializable]
public class InventorySlot{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount){
        item = _item;
        amount = _amount;
    }
    public void addAmount(int value){
        amount+= value;
    }
}