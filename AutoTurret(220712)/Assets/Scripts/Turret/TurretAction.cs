using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �ڸ�Ʈ: ~Behaviour�� ������� �ʴ� ���� ����. ����Ƽ�� �ߺ� �̸��� �� �� �ִ�.
public class TurretAction : MonoBehaviour
{
    public GameObject Body;

    public GameObject BulletPrefab;
    public Transform BulletPosition;

    public float SpinSpeed = 10f;
    public float MinShotTime = 0.5f;
    public float MaxShotTime = 0.9f;

    private TurretSence sence;
    private float shotRate;
    private float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        shotRate = Random.Range(MinShotTime, MaxShotTime);
        sence = GetComponent<TurretSence>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sence.IsPlayerAround)
        {
            ShotTarget();
        }
        else
        {
            Idle();
        }
    }

    private void ShotTarget()
    {
        Body.transform.LookAt(sence.Target);

        // ������ �ڸ�Ʈ: �����ִ� �ڵ� ���� ����α�
        currentTime += Time.deltaTime;
        if (currentTime >= shotRate)
        {
            currentTime = 0f;
            shotRate = Random.Range(MinShotTime, MaxShotTime);

            Instantiate(BulletPrefab, BulletPosition.position, Body.transform.rotation);
        }
    }

    private void Idle()
    {
        // ������ �ڸ�Ʈ: �ð� �� ȸ������ �ϴ� ���� ����. ���� Time.delatime ���ؾ��Ѵ�.
        Body.transform.Rotate(0f, SpinSpeed * Time.deltaTime, 0f);
        currentTime = 0f;
    }
}
