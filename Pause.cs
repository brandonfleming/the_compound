using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [Header("Player")]
    public GameObject Player;
    public GameObject Weapons;
    [Header("UI")]
    public GameObject Menu;

    public void Pausee ()
    {

        Time.timeScale = 0f;
        Menu.SetActive(true);
        Player.GetComponent<FirstPersonController>().enabled = false;
        Weapons.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Paused");

    }

    public void UnPause ()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        Weapons.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Resumed Game");
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausee();
        }

    }


}
