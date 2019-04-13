using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    [AddComponentMenu("Item")]
    [Header("Item Stats")]
    public string ItemName;
    public GameObject Item;

    [Header("UI")]
    public Text ui;

    [Header("Inventory")]
    public PlayerManager Inventory;
    private bool isinzone;

    private void Start()
    {
        isinzone = false;
        ui.text = " ";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Controller")
        {
            ui.text = "Press E to pickup " + ItemName;
            Debug.Log("Picking up: " + ItemName);
            isinzone = true;
        }
    }

    private void Update()
    {
        if (isinzone == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickupItem();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ui.text = " ";
        isinzone = false;
    }

    public void PickupItem ()
    {

        for (int i = 0; i < Inventory.Inventory.Length; i++)
        {
            if (Inventory.isFull[i] == false)
            {
                Inventory.Inventory[i] = Item.gameObject;
                Inventory.isFull[i] = true;
                ui.text = " ";
                Destroy(gameObject);
                break;
            }
        }

    }

}
