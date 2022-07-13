using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
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
        currentTime += Time.deltaTime;
        gameObject.transform.LookAt(sence.Target);

        if (currentTime >= shotRate)
        {
            currentTime = 0f;
            shotRate = Random.Range(MinShotTime, MaxShotTime);

            GameObject bullet = Instantiate(BulletPrefab, BulletPosition.position, transform.rotation);
        }
    }

    private void Idle()
    {
        transform.Rotate(0f, SpinSpeed, 0f);
        currentTime = 0f;
    }
}
