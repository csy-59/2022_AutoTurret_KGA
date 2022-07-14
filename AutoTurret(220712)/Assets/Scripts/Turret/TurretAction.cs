using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 교수님 코맨트: ~Behaviour을 사용하지 않는 것이 좋다. 유니티에 중복 이름이 들어갈 수 있다.
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

        // 교수님 코맨트: 관련있는 코드 끼리 묶어두기
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
        // 교수님 코맨트: 시간 당 회전으로 하는 것이 좋다. 역시 Time.delatime 곱해야한다.
        Body.transform.Rotate(0f, SpinSpeed * Time.deltaTime, 0f);
        currentTime = 0f;
    }
}
