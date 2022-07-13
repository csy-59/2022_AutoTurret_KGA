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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Target = other.gameObject.transform;
            IsPlayerAround = true;
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
