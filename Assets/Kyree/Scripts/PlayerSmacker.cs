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

    [Header("Settings")]
    public float timerToHit = 0;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = invisibleMaterial;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
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
        StartCoroutine(StartTimerToSmack());
    }

    private IEnumerator StartTimerToSmack()
    {
        StartCoroutine(SetMaterial());

        animator.SetBool("isSmacking", true);

        yield return new WaitForSeconds(0.75f);

        animator.SetBool("isSmacking", false);

        timerToHit = 0;
    }

    private IEnumerator SetMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = normalMaterial;

        yield return new WaitForSeconds(2);

        gameObject.GetComponent<MeshRenderer>().material = invisibleMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }
}
