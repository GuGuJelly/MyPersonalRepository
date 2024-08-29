using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // ����Ʈ�� �Ѿ��� ���� �� �ִ� ����Ʈ ����
    [SerializeField] List<PooledObject> pool = new List<PooledObject>();
    // �Ѿ� ������ ����
    [SerializeField] PooledObject prefab;
    // ����Ʈ ������ ����
    [SerializeField] int size;

    public void Awake()
    {
        for (int i = 0;i < size; i++) 
        {
            // PooledObject �� �Ѿ� ������ ����
            PooledObject instance = Instantiate(prefab);
            // �Ѿ� �������ڸ��� �߻���� �ʰ� OFF ���ѵα�
            instance.gameObject.SetActive(false);
            // ������ �Ѿ� �������� �θ������� �̵�
            instance.transform.parent = transform;
            // �ݳ��Ҷ� ���ƿ;� �ϴ� ���� ����
            instance.returnPool = this;
            pool.Add(instance);
        }
    }

    public PooledObject GetPool(Vector3 position,Quaternion rotation) 
    {
        // pool ����Ʈ�� �׿��ִ� �Ѿ��� ������ 0 ���� Ŭ��, �� �Ѿ��� �������� ��
        if (pool.Count > 0)
        {
            // pool�� ������� �ִ� �Ѿ��� ���� PooledObject instance �� �����´�.
            // ���� �������� ���� ������
            PooledObject instance = pool[pool.Count - 1];
            // �̷� ��ġ��
            instance.transform.position = position;
            // �̷� ȸ������ �����´�
            instance.transform.rotation = rotation;
            // �� ������ ����Ʈ �θ� ������Ʈ �ʿ� null�� �־��ش�
            instance.transform.parent = null;
            // �ݳ��Ҷ� ���ƿ;� �ϴ� ���� ����
            instance.returnPool = this;

            // �Ѿ��� OFF �س��� ���� ON �ѵд�
            instance.gameObject.SetActive(true);
            

            pool.RemoveAt(pool.Count - 1);

            return instance;
        }
        else 
        {
            PooledObject instance = Instantiate(prefab,position,rotation);
            // �ݳ��Ҷ� ���ƿ;� �ϴ� ���� ����
            // ���� ���� ��鵵 ���⿡ �ݳ��ǰ� ����
            instance.returnPool = this;
            return instance;
        }
    }

    // �ݳ��ϱ�
    public void ReturnPool(PooledObject instance) 
    {
        instance.gameObject.SetActive(false);
        // �ݳ��Ҷ��� �θ� �̵�
        instance.transform.parent = transform;
        // pool�� ����
        pool.Add(instance);

    }
}
