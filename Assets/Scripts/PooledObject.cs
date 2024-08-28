using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    // ObjectPool returnPool �� ������� �Ѿ� �����޴� ����
    public ObjectPool returnPool;
    // ������� �Ѿ��� �����޴µ����� �ɸ��� �ð�
    [SerializeField] float returnTime = 5;
    private float curTime;

    private void OnEnable()
    {
        // ������� �Ѿ��� �����޴� �ð��� ���ư��� �ִ� ���� �߰��ð�
        // �Ѿ��� �ϳ� �����ް� ���ο� �Ѿ��� �����ޱ� ���� �ʱ�ȭ
        curTime = returnTime;
    }

    private void Update()
    {
        curTime -= Time.deltaTime;
        if (curTime < 0) 
        {
            returnPool.ReturnPool(this);
        }
    }
}
