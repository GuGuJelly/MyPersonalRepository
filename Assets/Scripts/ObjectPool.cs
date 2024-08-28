using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // 리스트로 총알을 담을 수 있는 리스트 구현
    [SerializeField] List<PooledObject> pool = new List<PooledObject>();
    // 총알 프리팹 선언
    [SerializeField] PooledObject prefab;
    // 리스트 사이즈 변수
    [SerializeField] int size;

    public void Awake()
    {
        for (int i = 0;i < size; i++) 
        {
            // PooledObject 에 총알 프리팹 생성
            PooledObject instance = Instantiate(prefab);
            // 총알 생성되자마자 발사되지 않게 OFF 시켜두기
            instance.gameObject.SetActive(false);
            // 생성된 총알 프리팹을 부모쪽으로 이동
            instance.transform.parent = transform;
            instance.returnPool = this;
            pool.Add(instance);
        }
    }

    public PooledObject GetPool(Vector3 position,Quaternion rotation) 
    {
        // pool 리스트에 쌓여있는 총알의 갯수가 0 보다 클때, 즉 총알이 남아있을 때
        if (pool.Count > 0)
        {
            // pool에 만들어져 있는 총알을 전부 PooledObject instance 에 가져온다.
            PooledObject instance = pool[pool.Count - 1];
            // 이런 위치에
            instance.transform.position = position;
            // 이런 회전으로 빌려온다
            instance.transform.rotation = rotation;
            // 다 빼놓은 리스트 부모 오브젝트 쪽에 null을 넣어준다
            instance.transform.parent = null;
            instance.returnPool = this;
            // 총알을 OFF 해놨던 것을 ON 켜둔다
            instance.gameObject.SetActive(true);

            pool.RemoveAt(pool.Count - 1);

            return instance;
        }
        else 
        {
            PooledObject instance = Instantiate(prefab,position,rotation);
            instance.returnPool = this;
            return instance;
        }
    }

    public void ReturnPool(PooledObject instance) 
    {
        instance.gameObject.SetActive(false);
        instance.transform.parent = transform;
        pool.Add(instance);
    }
}
