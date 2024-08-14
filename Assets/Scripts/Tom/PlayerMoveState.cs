using UnityEngine;
public partial class PlayerStateManager
{
    public class PlayerMoveState : PlayerStateBase
    {
        
        public override void OnEnter(PlayerStateManager owner, PlayerStateBase prevState)
        {
            boundCount = 10;
            print(boundCount);
        }
        public override void OnUpdata(PlayerStateManager owner) {
            //ここにキーボード操作移動や反射方向を操作するプログラムを書く


            //これでステート変更
            owner.ChangeState(owner.reflectionState);
        
        }

        public override void OnExit(PlayerStateManager owner, PlayerStateBase prevState) { 
        
        
        }
    }
}
