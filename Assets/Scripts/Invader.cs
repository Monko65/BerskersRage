using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Invader : MonoBehaviour
{
    private static Invader _instance;
    public static int count = 0;
    public NavMeshAgent agent;
    public float invaderHP = 10;

    private void Update()
    {
        if (GameObject.Find("Valharn") != null)
        {
            //Sets the invader to keep chasing Valharn as long as Valharn exists
            agent.SetDestination(GameObject.FindGameObjectWithTag("Valharn").transform.position);
        }

        //Destroys invader if they run out of hp
        if (invaderHP <= 0)
        {
            //Adds to counts to advance wave then destroys itself
            count++;
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag.Contains("Attack"))
        {
            //If the invader enters Valharn's attack cone they will take damage
            invaderHP -= 10;
        }

    }
}
