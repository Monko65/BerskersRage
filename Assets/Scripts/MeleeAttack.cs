using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    Collider collide;

    private void Start()
    {
        collide = GetComponent<Collider>();
        collide.isTrigger = false;
    }

    void Update()
    {
        //Registers players attack cone as a trigger on mouse held
        if (Input.GetMouseButton(0))
        {
            collide.isTrigger = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            collide.isTrigger = false;
        }
    }
}
