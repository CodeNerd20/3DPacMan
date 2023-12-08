using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform exitPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Teleport(collision.transform);
        }
    }

    private void Teleport(Transform player)
    {
        player.position = exitPoint.position;
    }
}
