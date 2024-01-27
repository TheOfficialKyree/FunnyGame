using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WallPuncher : MonoBehaviour
{ 
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(MoveOut());
    }

    private IEnumerator MoveOut()
    {
        animator.SetBool("isSlamming", true);

        yield return new WaitForSeconds(1.25f);

        animator.SetBool("isSlamming", false);

        yield return new WaitForSeconds(3);

        StartCoroutine(MoveOut());
    }

}
