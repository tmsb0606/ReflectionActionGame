using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_test1 : MonoBehaviour
{
    private bool isJumping;
    float speed = 5.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Ray�̍쐬�@�@�@�@�@�@�@��Ray���΂����_�@�@�@��Ray���΂�����
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));

        //Ray�����������I�u�W�F�N�g�̏������锠
        RaycastHit hit;

        //Ray�̔�΂��鋗��
        float distance = 0.5f;

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector3(0, 1, 0) * speed;
            }
        }

        //Ray2�̍쐬�@�@�@�@�@�@�@��Ray���΂����_�@�@�@��Ray���΂�����
        Ray ray2 = new Ray(transform.position, new Vector3(1, 0, 0));

        //Ra2y�����������I�u�W�F�N�g�̏������锠
        RaycastHit hit2;

        //Ray2�̔�΂��鋗��
        float distance2 = 0.5f;

        if (!Physics.Raycast(ray2, out hit2, distance2))
        {
            //Debug.Log("����������");
            // D�L�[�i�E�ړ��j
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += speed * transform.right * Time.deltaTime;
            }
        }


        //Ray2�̍쐬�@�@�@�@�@�@�@��Ray���΂����_�@�@�@��Ray���΂�����
        Ray ray3 = new Ray(transform.position, new Vector3(-1, 0, 0));

        //Ra2y�����������I�u�W�F�N�g�̏������锠
        RaycastHit hit3;

        if (!Physics.Raycast(ray3, out hit3, distance2))
        {
            // A�L�[�i���ړ��j
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= speed * transform.right * Time.deltaTime;
            }
        }


        

        //�J�����̈ʒu���L���[�u�ɍ��킹��
        Vector3 vecCameraPos = transform.position;
        vecCameraPos.y += 1.0f;
        vecCameraPos.z -= 10.0f;
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.position = vecCameraPos;
    }
}
