using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPuncher : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Activate Ragdol Physics
        }
    }
}
