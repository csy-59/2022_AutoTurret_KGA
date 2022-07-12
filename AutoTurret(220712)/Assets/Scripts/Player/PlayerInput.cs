using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float X { get; private set; }
    public float Z { get; private set; }

    // Update is called once per frame
    void Update()
    {
        X = Z = 0f;

        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");
    }
}
