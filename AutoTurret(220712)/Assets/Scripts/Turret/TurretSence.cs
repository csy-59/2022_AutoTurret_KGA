using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSence : MonoBehaviour
{
    public Transform Target { get; private set; }
    public bool IsPlayerAround { get; private set; }

    // ������ �ڸ�Ʈ Stay�� �ƴ϶� Enter�� �� ���� ��. 
    // Stay�� �÷��̾ �׾����� ��Ҵ��� Ȯ���ϴ� �뵵�� ����ϴ� ���� ����.
    // Ȱ��ȭ Ȯ���ϴ� ���: Target.gameObject.activeSelf�� true false ���� �� �ִ�.
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
