using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour
{

    //OH MY GOD THAT IS A LOT OF THINGS!
    [Header("Player Stats")]
    [Range(0f, 100f)]
    public float Health;
    public Slider slider;

    private void Start()
    {
        Debug.Log("Player Health: " + Health);
        slider.minValue = 0f;
        slider.maxValue = 100f;
    }

    private void Update()
    {
        slider.value = Health;
    
    }
}
