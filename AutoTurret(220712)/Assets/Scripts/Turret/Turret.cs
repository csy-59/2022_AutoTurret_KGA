using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletPosition;

    public Transform Target;

    public float SpinSpeed = 10f;
    public float MinShotTime = 0.5f;
    public float MaxShotTime = 0.9f;

    private float shotRate;
    private float currentTime = 0f;
    private bool isPlayerAround = false;

    // Start is called before the first frame update
    void Start()
    {
        shotRate = Random.Range(MinShotTime, MaxShotTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerAround)
        {
            currentTime += Time.deltaTime;
            gameObject.transform.LookAt(Target);

            if(currentTime >= shotRate)
            {
                currentTime = 0;
                shotRate = Random.Range(MinShotTime, MaxShotTime);

                GameObject bullet = Instantiate(BulletPrefab, BulletPosition.position, transform.rotation);
                bullet.transform.LookAt(Target);
            }
        }
        else
        {
            transform.Rotate(0f, SpinSpeed, 0f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayerAround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayerAround = false;
        }
    }
}
