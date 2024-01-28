using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSmacker : MonoBehaviour
{
    [Header("Normal References")]
    public GameObject playerSmacker;
    public Rigidbody playerRBody;
    public Animator animator;
    public Transform spawnLocation;

    [Header("Material References")]
    public Material normalMaterial;
    public Material invisibleMaterial;

    [Header("Script References")]
    public ApplyForce applyForce;

    [Header("Settings")]
    public float timerToHit = 0;
    public float speed = 50;

    private void Start()
    {
        //gameObject.GetComponent<MeshRenderer>().material = invisibleMaterial;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // If the player doesnt move, then start the timer.

        if(playerRBody.velocity.magnitude >= 0)
        {
            timerToHit += Time.deltaTime;
        }
        else
        {
            timerToHit -= Time.deltaTime;
        }

        // Failsafe incase it goes below zero
        if(timerToHit <= 0)
        {
            timerToHit = 0;
        }

        // Checks if the timer has reached the limit to initate the smack
        TimerTillSmack();
        
        transform.position = Vector3.MoveTowards(transform.position, spawnLocation.position, speed);
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
        //StartCoroutine(SetMaterial());

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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            applyForce.ApplyForceToPlayer(100);
            Debug.Log("This hit the player");
        }
    }
}
