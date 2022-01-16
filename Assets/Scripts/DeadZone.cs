using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && !other.CompareTag("Player")) return;
        
        var player = other.GetComponent<Player>();

        if (player != null)
        {
            player.Damage();
        }

        var cc = other.GetComponent<CharacterController>();

        if (cc != null)
        {
            cc.enabled = false;
        }

        if (other != null) other.transform.position = respawnPoint.transform.position;

        StartCoroutine(CCEnableRoutine(cc));
    }

    IEnumerator CCEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }
}
