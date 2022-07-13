using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSence : MonoBehaviour
{
    public Transform Target { get; private set; }
    public bool IsPlayerAround { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Target = other.gameObject.transform;
            IsPlayerAround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsPlayerAround = false;
        }
    }
}
