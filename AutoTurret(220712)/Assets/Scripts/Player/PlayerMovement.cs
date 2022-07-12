using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    private Rigidbody rigid;
    private PlayerInput input;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedX = Speed * input.X;
        float speedZ = Speed * input.Z;

        rigid.AddForce(speedX, 0f, speedZ);
    }
}
