using UnityEngine;
public partial class PlayerStateManager
{
    public class PlayerMoveState : PlayerStateBase
    {
        private float mouseDownTime  = 0f;
        private float limitTime  = 1f;
        private int boundCountLimit = 5;
        private float speed = 5f;
        public override void OnEnter(PlayerStateManager owner, PlayerStateBase prevState)
        {
            boundCount = 0;
            print(boundCount);
            owner.GetComponent<TrailRenderer>().enabled = false;
            owner.GetComponent<Rigidbody>().useGravity = true;
        }
        public override void OnUpdata(PlayerStateManager owner) {
            //ここにキーボード操作移動や反射方向を操作するプログラムを書く

            //Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
            Ray ray = new Ray(owner.transform.position, new Vector3(0, -1, 0));

            //Rayが当たったオブジェクトの情報を入れる箱
            RaycastHit hit;

            //Rayの飛ばせる距離
            float distance = 1f;

            if (Physics.Raycast(ray, out hit, distance))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    owner.rb.velocity = new Vector3(0, 1, 0) * speed;
                }
            }

            //Ray2の作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
            Ray ray2 = new Ray(owner.transform.position, new Vector3(1, 0, 0));

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
                    owner.transform.position += speed * owner.transform.right * Time.deltaTime;
                }
            }


            //Ray2の作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
            Ray ray3 = new Ray(owner.transform.position, new Vector3(-1, 0, 0));

            //Ra2yが当たったオブジェクトの情報を入れる箱
            RaycastHit hit3;

            if (!Physics.Raycast(ray3, out hit3, distance2))
            {
                // Aキー（左移動）
                if (Input.GetKey(KeyCode.A))
                {
                    owner.transform.position -= speed * owner.transform.right * Time.deltaTime;
                }
            }




            //カメラの位置をキューブに合わせる
            Vector3 vecCameraPos = owner.transform.position;
            vecCameraPos.y += 1.0f;
            vecCameraPos.z -= 10.0f;
            GameObject camera = GameObject.Find("Main Camera");
            camera.transform.position = vecCameraPos;



            //ここに反射に移行するプログラムを書く
            if (Input.GetMouseButton(0))
            {
                
                mouseDownTime += Time.deltaTime;
                if(mouseDownTime > limitTime)
                {
                    boundCount++;
                    if(boundCount > boundCountLimit)
                    {
                        boundCount = 0;
                    }
                    mouseDownTime = 0;
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                mouseDownTime = 0;
                //これでステート変更

                if (boundCount > 0)
                {
                    owner.ChangeState(owner.reflectionState);
                }
                
            }
            
        }

        public override void OnExit(PlayerStateManager owner, PlayerStateBase prevState) {
                        //owner.reflectWall = null;
        
        }
    }
}
