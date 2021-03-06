﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSetup : MonoBehaviour
{
    //bool setupHasRan = false;

    [SerializeField]
    public StoreItems[] storeItems = new StoreItems[30];

    string jsonString;
    string jsonPath;

    

    [SerializeField]
    public Sprite[] itemSprites;

    [SerializeField]
    public ItemList itemData;

    void Awake()
    {
        if (!GlobalVariable.setupDone && GlobalVariable.jeuEnMarche)
        {
            jsonPath = Application.streamingAssetsPath + "/itemList.json";
            jsonString = File.ReadAllText(jsonPath);

            itemData = JsonUtility.FromJson<ItemList>(jsonString);

            for (int i = 0; i < 30; i++)
            {
                storeItems[i].itemName = ItemNameList.GeneralitemNames[i];
                storeItems[i].itemSprite = itemSprites[i];
                storeItems[i].price = itemData.itemList[i].itemPrice;
                storeItems[i].quality = itemData.itemList[i].itemQuality;
            }
            GlobalVariable.storeItems = storeItems;
            GlobalVariable.setupDone = true;
        }

        //GlobalVariable.hasStarted = true;
        //GlobalVariable.storeItems = storeItems;
        for (int i = 0; i < 30; i++)
        {
            Debug.Log("Dans la liste : " + storeItems[i].itemName);
        }
    }
}

[Serializable]
public class ItemList
{
    public List<ItemData> itemList;
}

[Serializable]
public class ItemData
{
    public int itemPrice;
    public int itemQuality;
}

[Serializable]
public class StoreItems
{
    public string itemName = "Fuck You";
    public Sprite itemSprite = null;
    public int price = 0;
    public int quality = 0;
    public bool purchased = false;
}
