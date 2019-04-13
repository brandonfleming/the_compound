using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class ItemSpawnConsole : MonoBehaviour
{
    public GameObject Player;
    public GameObject Weapons;

    [Header("Items")]
    public GameObject[] items;

    [Header("UI")]
    public GameObject UI;
    public InputField field;
    private string coninput;

    //Commands

    private void Start()
    {
        UI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            UI.SetActive(true);
            Player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Weapons.SetActive(false);
        }

    }

    public void Exit ()
    {
        UI.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Weapons.SetActive(true);
    }

    public void OnSubmit ()
    {
        coninput = field.text;

        if (coninput == "ump45")
        {
            Instantiate(items[0], gameObject.transform.position, Quaternion.identity);
        }

        if (coninput == "ammo")
        {
            Instantiate(items[1], gameObject.transform.position, Quaternion.identity);
        }

        if (coninput == "m9")
        {
            Instantiate(items[2], gameObject.transform.position, Quaternion.identity);
        }

    }

}
