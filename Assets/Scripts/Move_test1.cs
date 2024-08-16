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
        //Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));

        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;

        //Rayの飛ばせる距離
        float distance = 0.5f;

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector3(0, 1, 0) * speed;
            }
        }

        //Ray2の作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray ray2 = new Ray(transform.position, new Vector3(1, 0, 0));

        //Ra2yが当たったオブジェクトの情報を入れる箱
        RaycastHit hit2;

        //Ray2の飛ばせる距離
        float distance2 = 0.5f;

        if (!Physics.Raycast(ray2, out hit2, distance2))
        {
            //Debug.Log("当たったお");
            // Dキー（右移動）
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += speed * transform.right * Time.deltaTime;
            }
        }


        //Ray2の作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray ray3 = new Ray(transform.position, new Vector3(-1, 0, 0));

        //Ra2yが当たったオブジェクトの情報を入れる箱
        RaycastHit hit3;

        if (!Physics.Raycast(ray3, out hit3, distance2))
        {
            // Aキー（左移動）
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= speed * transform.right * Time.deltaTime;
            }
        }


        

        //カメラの位置をキューブに合わせる
        Vector3 vecCameraPos = transform.position;
        vecCameraPos.y += 1.0f;
        vecCameraPos.z -= 10.0f;
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.position = vecCameraPos;
    }
}
