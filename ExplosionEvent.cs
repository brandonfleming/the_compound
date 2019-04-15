using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEvent : MonoBehaviour
{
    [Header("FX")]
    public ParticleSystem explosion;
    public AudioSource sound;
    public GameObject rubble;
    public GameObject[] NearestLights;

    private void Start()
    {
        rubble.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(gameObject.transform.position, gameObject.transform.localScale);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
             StartCoroutine(Explosion());
        }

        if (explosion.isPlaying == true && sound.isPlaying == true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }

    IEnumerator Explosion ()
    {
        explosion.Play();
        sound.Play();
        rubble.SetActive(true);
        Debug.Log(gameObject.name + ": was activated");
        NearestLights[0].SetActive(false);
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<ExplosionEvent>().enabled = false;
    }

}