using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSence : MonoBehaviour
{
    public Transform Target { get; private set; }
    public bool IsPlayerAround { get; private set; }

    // 교수님 코맨트 Stay가 아니라 Enter가 더 좋을 듯. 
    // Stay는 플래이어가 죽었는지 살았는지 확인하는 용도로 사용하는 것이 좋다.
    // 활성화 확인하는 방법: Target.gameObject.activeSelf로 true false 받을 수 있다.
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 distanceVector = other.transform.position - transform.position;
            
            Vector3 cross = Vector3.Cross(transform.forward.normalized, distanceVector.normalized);
            float sin = cross.magnitude;
            if(cross.y > 0)
            {
                float cos = Vector3.Dot(transform.forward.normalized, distanceVector.normalized);
                
                if ((cos <= Mathf.Cos(0) && cos >= Mathf.Cos(Mathf.PI / 3)) && (sin >= Mathf.Sin(0) && sin <= Mathf.Sin(Mathf.PI / 3)))
                {
                    Target = other.gameObject.transform;
                    IsPlayerAround = true;
                }
            }
            else
            {
                IsPlayerAround = false;
            }
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
