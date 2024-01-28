using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 6f;

    private void Start()
    {
        characterController= GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horitzontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horitzontal, 0f, vertical).normalized;

        if(direction.magnitude >-0.1f)
        {
           characterController.Move(direction * speed * Time.deltaTime);
        }

    }
}