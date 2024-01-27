using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float destoryTimer;

    // Update is called once per frame
    void Update()
    {
        destoryTimer -= Time.deltaTime;

        if (destoryTimer < 0 )
        {
            Destroy(gameObject);
        }
    }
}
