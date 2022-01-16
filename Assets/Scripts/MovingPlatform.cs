using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Variables
    [SerializeField] private Transform targetA, targetB;
    [SerializeField] private float speed = 3.0f;
    private bool _switching = false;

    private void FixedUpdate()
    {
        switch (_switching)
        {
            case false:
                transform.position = Vector3.MoveTowards(transform.position, targetB.position, speed * Time.deltaTime);
                break;
            case true:
                transform.position = Vector3.MoveTowards(transform.position, targetA.position, speed * Time.deltaTime);
                break;
        }

        if (transform.position != targetB.position)
        {
            if (transform.position == targetA.position)
            {
                _switching = false;
            }
        }
        else
        {
            _switching = true;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.transform.parent = this.transform;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.transform.parent = null;
    }
}