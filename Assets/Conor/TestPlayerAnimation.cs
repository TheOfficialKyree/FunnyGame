using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerAnimation : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveForward();
        MoveBackward();
        MoveLeft();
        MoveRight();
        Jump();
    }

    private void MoveForward()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isWalkingForward", true);
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalkingForward", false);
        }
    }

    private void MoveBackward()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("isWalkingBack", true) ;
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isWalkingBack", false);
        }
    }

    private void MoveLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("isWalkingLeft", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isWalkingLeft", false);
        }
    }

    private void MoveRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("isWalkingRight", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isWalkingRight", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJump", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJump", false);
        }
    }

}
