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
            //�����ɃL�[�{�[�h����ړ��┽�˕����𑀍삷��v���O����������

            //Ray�̍쐬�@�@�@�@�@�@�@��Ray���΂����_�@�@�@��Ray���΂�����
            Ray ray = new Ray(owner.transform.position, new Vector3(0, -1, 0));

            //Ray�����������I�u�W�F�N�g�̏������锠
            RaycastHit hit;

            //Ray�̔�΂��鋗��
            float distance = 1f;

            if (Physics.Raycast(ray, out hit, distance))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    owner.rb.velocity = new Vector3(0, 1, 0) * speed;
                }
            }

            //Ray2�̍쐬�@�@�@�@�@�@�@��Ray���΂����_�@�@�@��Ray���΂�����
            Ray ray2 = new Ray(owner.transform.position, new Vector3(1, 0, 0));

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
                    owner.transform.position += speed * owner.transform.right * Time.deltaTime;
                }
            }


            //Ray2�̍쐬�@�@�@�@�@�@�@��Ray���΂����_�@�@�@��Ray���΂�����
            Ray ray3 = new Ray(owner.transform.position, new Vector3(-1, 0, 0));

            //Ra2y�����������I�u�W�F�N�g�̏������锠
            RaycastHit hit3;

            if (!Physics.Raycast(ray3, out hit3, distance2))
            {
                // A�L�[�i���ړ��j
                if (Input.GetKey(KeyCode.A))
                {
                    owner.transform.position -= speed * owner.transform.right * Time.deltaTime;
                }
            }




            //�J�����̈ʒu���L���[�u�ɍ��킹��
            Vector3 vecCameraPos = owner.transform.position;
            vecCameraPos.y += 1.0f;
            vecCameraPos.z -= 10.0f;
            GameObject camera = GameObject.Find("Main Camera");
            camera.transform.position = vecCameraPos;



            //�����ɔ��˂Ɉڍs����v���O����������
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
                //����ŃX�e�[�g�ύX

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
