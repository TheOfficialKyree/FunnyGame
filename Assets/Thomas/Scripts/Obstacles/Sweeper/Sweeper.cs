using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweeper : MonoBehaviour
{
    [SerializeField] bool start, end;
    [SerializeField] float speed;
    [SerializeField] float maxSpeed, minSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float timer;

    // Update is called once per frame
    void Update()
    {
        if (start && !end)
        {
            // Increase speed using Mathf.Lerp
            speed = Mathf.Lerp(speed, maxSpeed, acceleration * Time.deltaTime);

            // Rotate the GameObject around its up axis (Y-axis) based on the speed
            transform.Rotate(Vector3.up, speed * Time.deltaTime);

            timer -= Time.deltaTime;

            if(timer < 0)
            {
                end = true;
            }
        }

        if (start && end)
        {
            // Increase speed using Mathf.Lerp
            speed = Mathf.Lerp(speed, minSpeed, acceleration * Time.deltaTime);

            // Rotate the GameObject around its up axis (Y-axis) based on the speed
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            start = true;
        }
    }
}
