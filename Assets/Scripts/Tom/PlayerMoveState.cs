using UnityEngine;
public partial class PlayerStateManager
{
    public class PlayerMoveState : PlayerStateBase
    {
        private float mouseDownTime  = 0f;
        private float limitTime  = 1f;
        private int boundCountLimit = 5;
        public override void OnEnter(PlayerStateManager owner, PlayerStateBase prevState)
        {
            boundCount = 0;
            print(boundCount);
            owner.GetComponent<TrailRenderer>().enabled = false;
            owner.GetComponent<Rigidbody>().useGravity = true;
        }
        public override void OnUpdata(PlayerStateManager owner) {
            //�����ɃL�[�{�[�h����ړ��┽�˕����𑀍삷��v���O����������





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
            owner.reflectWall = null;
        
        }
    }
}
