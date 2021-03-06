﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemHandler : MonoBehaviour
{
    [SerializeField]
    private Image LocalitemSprite;
    [SerializeField]
    public Text LocalNameLabel;
    [SerializeField]
    public Text LocalitemPrice;

    public void SetAttributes(Sprite itemSprite, string itemName, int itemPrice)
    {
        LocalitemSprite.GetComponent<Image>().sprite = itemSprite;
        LocalNameLabel.GetComponent<Text>().text = itemName;
        LocalitemPrice.GetComponent<Text>().text = itemPrice.ToString();
    }
}
