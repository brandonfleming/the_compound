using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvenTrigger : MonoBehaviour
{

    [Header("Trigger")]
    public GameObject trigger;
    [Header("Event Audio")]
    public AudioSource audio;
    [Header("UI")]
    public Text text;
    [Header("Text")]
    public string Info;

    [Header("Event Types")]
    public bool Headsup;
    public bool Noise;


    private void OnTriggerEnter(Collider other)
    {
        
        if (Noise == true)
        {
            StartCoroutine(NoiseEvent());
        }

        if (Headsup == true)
        {
            StartCoroutine(HeadsupEvent());
        }

    }

    IEnumerator NoiseEvent ()
    {

        Debug.Log(gameObject.name + " Triggered");
        audio.Play();
        yield return new WaitForSeconds(3f);
        
        if (audio.isPlaying == false)
        {
            Destroy(gameObject);
        }


    }

    IEnumerator HeadsupEvent ()
    {
        text.text = Info;
        yield return new WaitForSeconds(3f);
        text.text = " ";
        Destroy(gameObject);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(gameObject.transform.position, gameObject.transform.localScale);
    }

}
