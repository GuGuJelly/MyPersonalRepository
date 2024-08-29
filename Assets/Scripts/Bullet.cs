using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed;

    private void Update()
    {
        transform.Translate(Vector3.forward*Speed*Time.deltaTime,Space.Self);
        // �ݳ��̴ϱ� ������Ű�� �ȵȴ�
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
