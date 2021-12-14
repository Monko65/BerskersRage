using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grape : MonoBehaviour
{
    private void OnTriggerEnter(Collider collide)
    {
        //If the Grape comes in contact with Valharn it will destroy itself
        if (collide.gameObject.tag.Contains("Valharn"))
        {
            Destroy(gameObject);
        }
    }
}
