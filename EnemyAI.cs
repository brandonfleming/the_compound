using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Health")]
    public float Health = 50f;

    [Header("Navmesh")]
    public NavMeshAgent agent;

    [Header("Look Radius")]
    [Range(1f, 100f)]
    public float lookRadius;
    public GameObject Player;

    //Distance
    Transform target;

    private void Start()
    {
        target = Player.transform;
    }

    //Draws the wire sphere
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void Update()
    {
        //Gets the distance between the enemy and the player
        float distance = Vector3.Distance(gameObject.transform.position, target.transform.position);

        if (distance < lookRadius)
        {
            Debug.Log(gameObject.name + " is Following the Player");
            agent.isStopped = false;
            agent.SetDestination(target.position);
        } else
        {
            agent.isStopped = true;
        }
    }


    public void TakeDamage(float amount)
    {
        Health -= amount;

        if (Health <= 0f)
        {
            die();
        }
    }

    public void die ()
    {

        Destroy(gameObject);

    }

}
