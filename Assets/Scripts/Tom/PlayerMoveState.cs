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
            //ここにキーボード操作移動や反射方向を操作するプログラムを書く





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
            owner.reflectWall = null;
        
        }
    }
}
