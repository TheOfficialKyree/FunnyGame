using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerSmacker : MonoBehaviour
{
    [Header("Normal References")]
    public GameObject playerSmacker;
    public Animator animator;

    [Header("Material References")]
    public Material normalMaterial;
    public Material invisibleMaterial;

    [Header("Script References")]
    public PlayerScript2 playerScript2;

    [Header("Settings")]
    public float timerToHit = 0;
    public bool canSmack = false;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = invisibleMaterial;
        animator = GetComponent<Animator>();
        //playerScript2 = GameObject.FindObjectOfType<PlayerScript2>();
    }

    private void Update()
    {
        // If the player doesnt move, then start the timer.
        /*
        if(playerScript2.isMoving == false)
        {
            timerToHit += Time.deltaTime;
        }
        else
        {
            timerToHit -= Time.deltaTime;
        }
        */

        // Checks if the timer has reached the limit to initate the smack
        TimerTillSmack();
    }

    public void TimerTillSmack()
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

        // Wait
        yield return new WaitForSeconds(0.75f);

        // Resets The Settigs
        animator.SetBool("isSmacking", false);
        timerToHit = 0;
    }

    private IEnumerator SetMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = normalMaterial;

        yield return new WaitForSeconds(1.59f);

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
