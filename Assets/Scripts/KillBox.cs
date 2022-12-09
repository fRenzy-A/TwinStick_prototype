using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public Transform respawn_point;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawn_point.transform.position;
        }

    }
}
