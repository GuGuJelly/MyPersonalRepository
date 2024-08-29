using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed;

    private void Update()
    {
        transform.Translate(Vector3.forward*Speed*Time.deltaTime,Space.Self);
        // 반납이니까 삭제시키면 안된다
        // BulletDestroy();
    }

    public void SetSpeed(float speed)
    {
        this.Speed = speed;
    }

    //public void BulletDestroy() 
    //{
    //    Destroy(gameObject, 3f);
    //}
}
