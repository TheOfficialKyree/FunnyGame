using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RagdollOnOff : MonoBehaviour
{
    public CapsuleCollider mainCoillider;
    public GameObject characterRig;
    public Animator characterAnimator;
    
    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obsticle"))
        {
            RagdollModeOn();
            StartCoroutine(Example());
        }
    }

    IEnumerator Example()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(5);
        Debug.Log(Time.time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
