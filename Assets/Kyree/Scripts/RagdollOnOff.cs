using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnOff : MonoBehaviour
{
    public BoxCollider mainCoillider;
    public GameObject characterRig;
    public Animator characterAnimator;
    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hit")
        {
            RagdollModeOn();
        }
    }

    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidbodies;
    void GetRagdollBits()
    {
        ragdollColliders = characterRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = characterRig.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollModeOn()
    {
        characterAnimator.enabled = false;

        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }

        
        mainCoillider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void RagdollModeOff()
    {
        foreach(Collider col in ragdollColliders)
        {
            col.enabled = false;
        }

        foreach(Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }

        characterAnimator.enabled = true;
        mainCoillider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
