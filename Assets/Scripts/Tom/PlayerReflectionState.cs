using UnityEngine;

public partial class PlayerStateManager
{
    public class PlayerReflectionState : PlayerStateBase
    {
        public override void OnEnter(PlayerStateManager owner, PlayerStateBase prevState)
        {
            boundCount = prevState.boundCount;
            print(boundCount);
        }

        public override void OnUpdata(PlayerStateManager owner)
        {
            //反射するプログラムを書く


        }

        public override void OnExit(PlayerStateManager owner, PlayerStateBase prevState)
        {


        }
    }
}
