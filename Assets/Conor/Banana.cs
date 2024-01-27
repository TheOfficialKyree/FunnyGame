using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // Add ragdoll physiscs

            Destroy(gameObject);
        }
    }
}
