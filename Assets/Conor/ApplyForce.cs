using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    public Rigidbody[] rb;

    private void Start()
    {
        rb = GetComponentsInChildren<Rigidbody>();
    }

    public void ApplyForceToPlayer(float magnitude)
    {
        foreach(Rigidbody rb in rb)
        {
            rb.AddForce(Vector3.forward * magnitude, ForceMode.Impulse);
        }
    }
}
