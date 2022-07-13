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

        // 교수님 코맨트: velocity를 이용하는 것이 더 자연스런 움직임을 줄 수 있음
        rigid.AddForce(speedX, 0f, speedZ);
    }
}
