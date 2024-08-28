using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    //[SerializeField] float rotateSpeed;
    [SerializeField] float rate;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir == Vector3.zero)
            return;

        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);

        Quaternion lookRot = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, rate * Time.deltaTime);
        //transform.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime, Space.World);

    }
}
