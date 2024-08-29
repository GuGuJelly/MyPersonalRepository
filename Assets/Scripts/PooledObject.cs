using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    // ObjectPool returnPool 로 빌려줬던 총알 돌려받는 변수
    // 돌아가야 할 pool 을 가지고 있어야 하니까 선언
    public ObjectPool returnPool;

    // 빌려줬던 총알을 돌려받는데까지 걸리는 시간
    // 몇초 뒤에 반납돼야 할지 걸리는 시간
    [SerializeField] float returnTime = 5;

    private float curTime;

    private void OnEnable()
    {
        // 빌려줬던 총알을 돌려받는 시간이 돌아가고 있는 현재 중간시간
        // 총알을 하나 돌려받고 새로운 총알을 돌려받기 위한 초기화
        // 활성화 됐을 때부터 몇초가 지나야 반납할지 정한다
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
