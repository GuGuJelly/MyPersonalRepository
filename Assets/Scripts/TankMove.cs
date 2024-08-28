using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x,0,z);

        if (moveDir.magnitude > 1 ) 
        {
            moveDir.Normalize();
        }
        transform.Translate(moveDir.normalized*moveSpeed*Time.deltaTime,Space.World);

        transform.Rotate(Vector3.up,rotateSpeed*Time.deltaTime);
    }
}
