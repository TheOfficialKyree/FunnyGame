using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerSmacker : MonoBehaviour
{
    [Header("References")]
    public GameObject playerSmacker;
    public Animator animator;
    public Material normalMaterial;
    public Material invisibleMaterial;
    public PlayerScript2 playerScript2;

    public BoxCollider box;

    [Header("Settings")]
    public float timerToHit = 0;
    public bool canSmack = false;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = invisibleMaterial;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //if(playerScript2.rb.velocity == 0)
        TimerToHit();

        timerToHit += Time.deltaTime;
    }

    public void TimerToHit()
    {
        // Checks if the timer is five
        if(timerToHit >= 5)
        {
            StartPlayerSmack();
        }
    }

    public void StartPlayerSmack()
    {
        StartCoroutine(StartSmack());
    }

    private IEnumerator StartSmack()
    {
        // Sets material to visible
        StartCoroutine(SetMaterial());
       
        //Sets can smack to true
        StartCoroutine(SetSmackingTrue()); 

        // Starts the smacking animation
        animator.SetBool("isSmacking", true);

        box.enabled = true;

        // Wait
        yield return new WaitForSeconds(0.75f);

        // Resets The Settigs
        animator.SetBool("isSmacking", false);
        timerToHit = 0;

        box.enabled = false;
    }

    private IEnumerator SetMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = normalMaterial;

        yield return new WaitForSeconds(2);

        gameObject.GetComponent<MeshRenderer>().material = invisibleMaterial;
    }

    private IEnumerator SetSmackingTrue()
    {
        canSmack = true;

        yield return new WaitForSeconds(2);

        canSmack = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (canSmack == true)
            {
                //activate ragdoll physics
                Debug.Log("This hit the player");
            }
        }
    }
}
