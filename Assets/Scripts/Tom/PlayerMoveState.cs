using UnityEngine;
public partial class PlayerStateManager
{
    public class PlayerMoveState : PlayerStateBase
    {
        
        public override void OnEnter(PlayerStateManager owner, PlayerStateBase prevState)
        {
            boundCount = 0;
            print(boundCount);
        }
        public override void OnUpdata(PlayerStateManager owner) {
            //ここにキーボード操作移動や反射方向を操作するプログラムを書く





            //ここに反射に移行するプログラムを書く
            if (Input.GetMouseButton(0))
            {
                boundCount++;
            }
            if (Input.GetMouseButtonUp(0))
            {
                //これでステート変更
                owner.ChangeState(owner.reflectionState);
            }
            
        }

        public override void OnExit(PlayerStateManager owner, PlayerStateBase prevState) { 
        
        
        }
    }
}
