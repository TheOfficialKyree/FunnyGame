using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public ApplyForce applyForce;

    private void Start()
    {
        applyForce = FindObjectOfType<ApplyForce>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            applyForce.ApplyForceToPlayer(80);

            Destroy(gameObject);
        }
    }
}
