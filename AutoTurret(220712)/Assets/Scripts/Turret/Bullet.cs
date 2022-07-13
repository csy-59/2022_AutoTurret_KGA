using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeTime = 3f;
    public float Speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 교수님 코맨트: 시간당 몇을 정확히 가고 싶다면 speed에 Time.deltaTime을 곱해야 한다
        transform.Translate(0f, 0f, Speed * Time.deltaTime);
    }
}
