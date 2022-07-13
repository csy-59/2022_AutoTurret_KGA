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
        // ������ �ڸ�Ʈ: �ð��� ���� ��Ȯ�� ���� �ʹٸ� speed�� Time.deltaTime�� ���ؾ� �Ѵ�
        transform.Translate(0f, 0f, Speed * Time.deltaTime);
    }
}
