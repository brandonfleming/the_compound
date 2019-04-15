using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInventory : MonoBehaviour
{

    [Header("Gameobject Slots")]
    public GameObject[] Inventory;
    public GameObject[] ItemInformation;
    [Header("Inventory Slots Status ")]
    public bool[] isFull;
    public bool[] MiscIsFull;
    [Header("Inventory UI")]
    public Text[] slots;
    public Text[] MiscSlots;
    public Text[] Buttons;
    [Header("UI for Interfaces")]
    public GameObject[] Interface;
    public GameObject InvUI;
    public GameObject ItemUI;
    [Header("Player Weapons")]
    public GameObject weapons; // to stop player from shooting when in inventory



    public void CloseInventory()
    {
        GetComponentInParent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InvUI.SetActive(false);
        weapons.SetActive(true);
    }

    public void ShowInventory()
    {
        Interface[0].SetActive(false);

        if (ItemUI.activeInHierarchy == true)
        {
            ItemUI.SetActive(false);
        }

    }

    public void ShowStory()
    {
        Interface[0].SetActive(true);
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GetComponentInParent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            InvUI.SetActive(true);
            weapons.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Inventory[0].transform.gameObject.SetActive(true);

            if (Inventory[1] != null && isFull[1] == true)
            {
                Inventory[1].transform.gameObject.SetActive(false);
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Inventory[1].transform.gameObject.SetActive(true);
            Inventory[0].transform.gameObject.SetActive(false);

            if (Inventory[1] == null && isFull[1] == false)
            {
                Debug.LogWarning("No item in Slot 2!");
            }
        }

    }

}
