using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UMPAmmo : MonoBehaviour
{
    [Header("Ammo")]
    public float AmmoHeld = 150;
    [Header("Gun to add Ammo to")]
    public GameObject Gun;
    [Header("UI")]
    public Text ui;
    public string uitext;
    private bool isinzone;

    private void Start()
    {
        isinzone = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.transform.tag == "Controller")
        {
            ui.text = uitext;
            isinzone = true;

        }

    }

    private void Update()
    {
        if (isinzone == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickupAmmo();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ui.text = " ";
        isinzone = false;
    }

    void PickupAmmo()
    {
        Debug.Log(Gun.GetComponent<UMP45>().reserve + " : " + AmmoHeld + " : Ammo Added");
        Gun.GetComponent<UMP45>().reserve = Gun.GetComponent<UMP45>().reserve + AmmoHeld;
        ui.text = " ";
        Destroy(gameObject);
    }

}