using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    [Header("Item")]
    public GameObject Item;
    public GameObject ItemUI;
    public Text[] ui;

    public void OnClick()
    {

        ItemUI.SetActive(true); //Sets the item closeup screen to show
        Debug.Log("Showing Item Screen"); 
        ui[0].text = Item.GetComponent<Pickup>().ItemName; // The item name to show
        ui[1].text = Item.GetComponent<Pickup>().ItemDescription; // the item description to show

    }

}
