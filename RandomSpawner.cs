using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [Header("Items Can Spawn")]
    public GameObject[] Pickup;
    [Header("Random Number")]
    public int Rand;
    [Header("Optional: Item MUST spawn")]
    public bool MustSpawn;
    public GameObject Item;
    [Header("Spawn Item")]
    public bool SpawnItem;

    private void Start()
    {

        if (MustSpawn == true)
        {
            Instantiate(Item, gameObject.transform.position, Quaternion.identity);
            Debug.Log("Hard Spawned: " + Item.gameObject.name + " At " + gameObject.transform.position);
        }

        if (SpawnItem == true)
        {
            Rand = Random.Range(0, Pickup.Length);
            Instantiate(Pickup[Rand], gameObject.transform.position, Quaternion.identity);
            Debug.Log("Spawned: " + Pickup[Rand].gameObject.transform.name + " At " + gameObject.transform.position);
        }

    }

    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));

    }

}
